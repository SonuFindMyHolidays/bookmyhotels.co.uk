using Business.GetMeRoom;
using Data.GetMeRoom.Models;
using Data.GetMeRoom.Models.PreBook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using static Data.GetMeRoom.GlobalConstant;

namespace Data.GetMeRoom
{
    public static class PhonePeInit
    {
        public static void InitiateGateway(string guid, int bookingAmount)
        {
            var PHONEPE_MERCHANTID = ConfigVariables.PHONEPE_MERCHANTID;
            var PHONEPE_MERCHANTUSERID = ConfigVariables.PHONEPE_MERCHANTUSERID;
            PreBookRS_V1 preBookRS = (PreBookRS_V1)HttpContext.Current.Session["PreBookRS"];
            var data = new Dictionary<string, object>
            {
                { "merchantId", PHONEPE_MERCHANTID },
                { "merchantTransactionId", guid}, //Guid.NewGuid().ToString() 
                { "merchantUserId", PHONEPE_MERCHANTUSERID},
                { "amount", bookingAmount },
                { "redirectUrl", ConfigVariables.SITEROOTPATH+"Hotel/Success" },
                { "redirectMode", "POST" },
                { "callbackUrl",  ConfigVariables.SITEROOTPATH+"Hotel/CallBack" },
                { "mobileNumber", "9999999999" },
                { "paymentInstrument", new Dictionary<string, string> { { "type", "PAY_PAGE" } } }
            };


            var encode = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            var saltKey = ConfigVariables.PHONEPE_SALTKEY;
            var saltIndex = 1;
            var stringToHash = encode + "/pg/v1/pay" + saltKey;
            var sha256 = CommonMethods.sha256_hash(stringToHash);
            //var sha256 = BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(stringToHash))).Replace("-", "");
            var finalXHeader = sha256 + "###" + saltIndex;

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                //  client.DefaultRequestHeaders.TryAddWithoutValidation("X-VERIFY", finalXHeader);
                //              client.DefaultRequestHeaders
                //.Accept
                //.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-VERIFY", finalXHeader);
                //ACCEPT header

                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                //request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                //                                    Encoding.UTF8,
                //                                    "application/json");//CONTENT-TYPE header

                var requestData = new Dictionary<string, string> { { "request", encode } };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                //var response = await client.PostAsync("https://api-preprod.phonepe.com/apis/merchant-simulator/pg/v1/pay", content);

                // HttpResponseMessage httpResponse = client.PostAsync(ConfigVariables.PHONEPE_GATEWAYURL + "/pg/v1/pay", content).Result;
                var response = client.PostAsync(ConfigVariables.PHONEPE_GATEWAYURL + "/pg/v1/pay", content).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;
                //var rData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                //JObject rss = JObject.Parse(responseContent);
                //string rssTitle = (string)rss["data"]["instrumentResponse"]["redirectInfo"]["url"];

                //return Redirect(rssTitle);
                PhonePayInitRS rData = JsonConvert.DeserializeObject<PhonePayInitRS>(responseContent);

                if (rData.success && rData.code == "PAYMENT_INITIATED")
                {
                    if (rData?.data?.instrumentResponse?.redirectInfo?.url != null)
                    {
                        HttpContext.Current.Response.Redirect(rData?.data?.instrumentResponse?.redirectInfo?.url);
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect(ConfigVariables.SITEROOTPATH + "Hotel/Error?PayFor=ONL&BookingID=" + preBookRS.ResponseInfo.BookingToken + "&Provider=" + preBookRS.Hotel.HotelCodeContext + "&uid=" + guid + "&hotel_info=" + preBookRS.Hotel.Code);
                    }
                }
            }

        }
    }
}
