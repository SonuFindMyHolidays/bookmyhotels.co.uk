using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Business.GetMeRoom;
using Data.GetMeRoom.Models;
using Data.GetMeRoom.Models.PreBook;
using Newtonsoft.Json;
using NLog;
using paytm;
using static Data.GetMeRoom.GlobalConstant;

namespace GetMeRoom.Controllers
{
    public class TransactionProcessController : Controller
    {

        private BusinessAPICall businessAPICall = null;
        public readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly string bookingType = ConfigVariables.TRANCATIONTYPE.ToLower();
        // GET: TransactionProcess
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> MakePaymentRequest(PaytmPaymentRequestViewModel model)
        {
            string GatewayUrl = string.Empty;
            if (bookingType == "test")
            {
                GatewayUrl = ConfigVariables.STAGINGURL;
            }
            else
            {
                GatewayUrl = ConfigVariables.PRODUCTIONURL;
            }
            try
            {
                /* initialize a TreeMap object */
                Dictionary<string, string> paytmParams = new Dictionary<string, string>
                {
                    // Merchant Id
                    { PaytmParamKeys.MId, ConfigVariables.MERCHANTID},

                    // Website
                    { PaytmParamKeys.WEBSITE, ConfigVariables.WEBSITE },

                    // Industry Type Id
                    { PaytmParamKeys.INDUSTRY_TYPE_ID, ConfigVariables.INDUSTRYTYPE },

                    // Chanel Id
                    { PaytmParamKeys.CHANNEL_ID, ConfigVariables.CHANNELID },

                    // Order id generated from website
                    { PaytmParamKeys.ORDER_ID, model.OrderID},

                    // Customer Id generated from Website
                    { PaytmParamKeys.CUST_ID, model.BookingID },

                    // From model
                    { PaytmParamKeys.MOBILE_NO, model.PhoneNumber.Trim() },

                    // From model
                    { PaytmParamKeys.EMAIL, model.Emailid.Trim() },

                    // From model
                    { PaytmParamKeys.TXN_AMOUNT, model.GrandTotal.ToString() },

                    // Response will be sent to this url
                    { PaytmParamKeys.CALLBACK_URL, ConfigVariables.CALLBACKURL}
                };

                string checksum = CheckSum.generateCheckSum(ConfigVariables.MERCHANTKEY, paytmParams);//merchant Key
                /* Prepare HTML Form and Submit to Paytm */
                string outputHtml = "";
                outputHtml += "<html>";
                outputHtml += "<head>";
                outputHtml += "<title>Merchant Checkout Page</title>";
                outputHtml += "</head>";
                outputHtml += "<body>";
                outputHtml += "<center><h1>Please do not refresh this page...</h1></center>";
                outputHtml += "<form method='post' action='" + GatewayUrl + "' name='paytm_form'>";
                foreach (string key in paytmParams.Keys)
                {
                    outputHtml += "<input type='hidden' name='" + key + "' value='" + paytmParams[key] + "'>";
                }
                outputHtml += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
                outputHtml += "</form>";
                outputHtml += "<script type='text/javascript'>";
                outputHtml += "document.paytm_form.submit();";
                outputHtml += "</script>";
                outputHtml += "</body>";
                outputHtml += "</html>";

                ViewBag.HtmlData = outputHtml;
            }
            catch (Exception ex)
            {
                Log.Error("Error While payment with gateway : " + ex.Message, "MakePaymentRequest", "TransactionProcessController");
            }
            return View();
        }

        public async Task<ActionResult> GetPaytmResponse(PaymentResponseViewModel model)
        {
            PaymentResponseViewModelRs _paymentRs;
            #region Save Transaction Data into DB
            try
            {
                businessAPICall = new BusinessAPICall();
                _paymentRs = new PaymentResponseViewModelRs();
                _paymentRs = businessAPICall.SavePaytmPaymentResponse(model);
            }
            catch (Exception ex)
            {
                Log.Error("Error While gettong payment response with gateway : " + ex.Message, "GetPaytmResponse", "TransactionProcessController");
                throw;
            }
            #endregion Save Transaction Data into DB

            try
            {
                string paytmChecksum = "";
                Dictionary<string, string> paytmParams = new Dictionary<string, string>();
                foreach (string key in Request.Form.Keys)
                {
                    if (key.Equals("CHECKSUMHASH"))
                    {
                        paytmChecksum = Request.Form[key];
                    }
                    else
                    {
                        paytmParams.Add(key.Trim(), Request.Form[key].Trim());
                    }
                }

                bool isValidChecksum = CheckSum.verifyCheckSum(ConfigVariables.MERCHANTKEY, paytmParams, paytmChecksum);
                if (isValidChecksum)
                {
                    Data.GetMeRoom.Models.Book.BookRQ_V1 bookRQ = null;

                    if (model.RESPCODE == "01")
                    {
                        //ViewBag.Message = "Payment Successfull";

                        #region Get Booking Request from database
                        try
                        {
                            Data.GetMeRoom.Models.Book.BookingReqDataRs _bookingRqDataRS = new Data.GetMeRoom.Models.Book.BookingReqDataRs();
                            Data.GetMeRoom.Models.Book.InsertBookingDataRQ BookingRequestData = new Data.GetMeRoom.Models.Book.InsertBookingDataRQ
                            {
                                Action = 2,
                                Product = "HOTEL",
                                TransactionId = model.ORDERID
                            };

                            businessAPICall = new BusinessAPICall();

                            _bookingRqDataRS = businessAPICall.GetBookingRq(BookingRequestData);
                            Session["BookingReqDataRs"] = _bookingRqDataRS;
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error While gettong payment response with gateway : " + ex.Message, "GetPaytmResponse", "TransactionProcessController");
                            throw;
                        }
                        #endregion Get Booking Request from database

                        return RedirectToActionPermanent("HotelBookingProcess", "Hotel");
                    }
                    else
                    {
                        ViewBag.Message = "Payment Failed";
                        ViewBag.ErrorDetail = model.RESPMSG;
                        Log.Error("Error While getting payment response with gateway ResponseMessage: " + model.RESPMSG, "GetPaytmResponse", "TransactionProcessController");
                    }
                }
                else
                {
                    ViewBag.Message = "Checksum Mismatched";
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error While getting payment response with gateway : " + ex.Message, "GetPaytmResponse", "TransactionProcessController");
            }

            return View(model);
        }

        public async Task<ActionResult> PhonePeAsync(string guid)
        {
            //string guid = Convert.ToString(Session["guid"]);
            var PHONEPE_MERCHANTID = ConfigVariables.PHONEPE_MERCHANTID;
            var PHONEPE_MERCHANTUSERID = ConfigVariables.PHONEPE_MERCHANTUSERID;
            PreBookRS_V1 preBookRS = (PreBookRS_V1)Session["PreBookRS"];
            var data = new Dictionary<string, object>
            {
                { "merchantId", PHONEPE_MERCHANTID },
                { "merchantTransactionId", guid}, //Guid.NewGuid().ToString() 
                { "merchantUserId", PHONEPE_MERCHANTUSERID},
                { "amount", 10000 },
                { "redirectUrl", ConfigVariables.SITEROOTPATH+Url.Action("Response") },
                { "redirectMode", "POST" },
                { "callbackUrl",  ConfigVariables.SITEROOTPATH+Url.Action("Response")  },
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

            using (var client = new HttpClient())
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
                var response = await client.PostAsync(ConfigVariables.PHONEPE_GATEWAYURL + "/pg/v1/pay", content);
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
                        Redirect(rData?.data?.instrumentResponse?.redirectInfo?.url + "?guid=" + guid);
                    }
                    else
                    {
                        Redirect(ConfigVariables.SITEROOTPATH + "/Hotel/Error?PayFor=ONL&BookingID=" + preBookRS.ResponseInfo.BookingToken + "&Provider=" + preBookRS.Hotel.HotelCodeContext + "&uid=" + guid + "&hotel_info=" + preBookRS.Hotel.Code);
                    }
                }
            }

            Redirect(ConfigVariables.SITEROOTPATH + "/Hotel/Error?PayFor=ONL&BookingID=" + preBookRS.ResponseInfo.BookingToken + "&Provider=" + preBookRS.Hotel.HotelCodeContext + "&uid=" + guid + "&hotel_info=" + preBookRS.Hotel.Code);

            return View();
        }

    }
}