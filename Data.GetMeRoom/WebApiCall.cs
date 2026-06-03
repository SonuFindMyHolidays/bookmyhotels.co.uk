using Data.GetMeRoom.Models;
using Data.GetMeRoom.Models.Book;
using Data.GetMeRoom.Models.Detail;
using Data.GetMeRoom.Models.PreBook;
using Data.GetMeRoom.Models.Search;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Data.GetMeRoom
{
    public static class WebApiCall
    {

        public static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public static async Task<List<Location>> GetLocation(string strLocation)
        {
            List<Location> _location = new List<Location>();
            string ENDPOINT = GlobalConstant.ConfigVariables.ENDPOINT;

            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri(ENDPOINT);

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP GET  
                response = await client.GetAsync("hotel/Location/GetLocation?term=" + strLocation).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;

                    try
                    {
                        _location = JsonConvert.DeserializeObject<List<Location>>(result);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.Message, "Error while calling GetLocation method");
                    }
                }
            }
            return _location;
        }



        private static string GetResponse(object _Object, string WebApiMethod = "hotel/Search")
        {
            string ENDPOINT = GlobalConstant.ConfigVariables.ENDPOINT;
            string ResponseString = "";
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ENDPOINT + WebApiMethod);
                request.Accept = "application/json"; //"application/xml";
                request.Method = "POST";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                // serialize into json string
                var myContent = jss.Serialize(_Object);

                var data = Encoding.ASCII.GetBytes(myContent);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    ResponseString = "Some error occured: " + response.StatusCode.ToString();
                }
                else
                {
                    ResponseString = "Some error occured: " + ex.Status.ToString();
                }
            }
            return ResponseString;
        }



        public static SearchRS_V1 HotelSearch(SearchRQ_V1 searchRequest)
        {
            SearchRS_V1 _searchRS = new SearchRS_V1();
            //string WebApiMethod = "hotel/Search";
            string WebApiMethod = "Hotel/hotel_search";

            try
            {
                string strponse = GetResponse(searchRequest, WebApiMethod);
                _searchRS = JsonConvert.DeserializeObject<SearchRS_V1>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While Calling Hotel Search on WebApiCall-> HotelSearch");
            }

            return _searchRS;
        }

        public static GetRoomsRS_V1 HotelDetail(GetRoomsRQ_V1 getRoomRQ)
        {
            GetRoomsRS_V1 _getRoomRS = new GetRoomsRS_V1();
            //string WebApiMethod = "hotel/GetRoom";
            string WebApiMethod = "hotel/hotel_get_room";

            try
            {
                string strponse = GetResponse(getRoomRQ, WebApiMethod);
                _getRoomRS = JsonConvert.DeserializeObject<GetRoomsRS_V1>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While Calling Hotel Search on WebApiCall-> HotelDetail");
            }

            return _getRoomRS;
        }

        public static PreBookRS_V1 HotelPaymentMethod(PreBookRQ_V1 preBookRQ)
        {
            PreBookRS_V1 _getPreBookRS = new PreBookRS_V1();
            //string WebApiMethod = "hotel/PreBook";
            string WebApiMethod = "hotel/hotel_pre_book";

            try
            {
                string strponse = GetResponse(preBookRQ, WebApiMethod);
                _getPreBookRS = JsonConvert.DeserializeObject<PreBookRS_V1>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While Calling Hotel Search on WebApiCall-> HotelDetail:");

            }
            return _getPreBookRS;
        }

        public static BookRS_V1 HotelBookMethod(BookRQ_V1 BookRQ)
        {
            BookRS_V1 _getBookRS = new BookRS_V1();
            //string WebApiMethod = "hotel/Booking";
            string WebApiMethod = "Hotel/hotel_booking";
            try
            {
                string strponse = GetResponse(BookRQ, WebApiMethod);
                //Log.Info("Booking Response on WebApiCall.cs HotelBooking():- " + strponse);
                _getBookRS = JsonConvert.DeserializeObject<BookRS_V1>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While Calling Hotel Book on WebApiCall-> HotelBookMethod:");

            }
            return _getBookRS;
        }

        public static PaymentResponseViewModelRs SavePaytmPaymentResponse(PaymentResponseViewModel model)
        {
            PaymentResponseViewModelRs _paymentRS = new PaymentResponseViewModelRs();
            string WebApiMethod = "hotel/Booking/InsertPaymentInfo";

            try
            {
                string strponse = GetResponse(model, WebApiMethod);
                //Log.Info("Booking Response on WebApiCall.cs HotelBooking():- " + strponse);
                _paymentRS = JsonConvert.DeserializeObject<PaymentResponseViewModelRs>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While saving payment info in DB hotel/Booking/  on WebApiCall-> InsertPaymentInfo:");

            }
            return _paymentRS;
        }


        public static Models.Book.InsertBookingDataRS InsertBookingRq(Models.Book.InsertBookingDataRQ model)
        {
            Models.Book.InsertBookingDataRS _inertBokingRS = new Models.Book.InsertBookingDataRS();
            string WebApiMethod = "hotel/Booking/InsertBookingRq";

            try
            {
                string strponse = GetResponse(model, WebApiMethod);
                //Log.Info("Booking Response on WebApiCall.cs HotelBooking():- " + strponse);
                _inertBokingRS = JsonConvert.DeserializeObject<Models.Book.InsertBookingDataRS>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While inserting booking request info in DB hotel/Booking/  on WebApiCall-> InsertBookingRq:");

            }
            return _inertBokingRS;
        }


        public static Models.Book.BookingReqDataRs GetBookingRq(Models.Book.InsertBookingDataRQ model)
        {
            Models.Book.BookingReqDataRs _bookingReqDataRs = new Models.Book.BookingReqDataRs();
            string WebApiMethod = "hotel/Booking/GetBookingRq";

            try
            {
                string strponse = GetResponse(model, WebApiMethod);
                //Log.Info("Booking Response on WebApiCall.cs HotelBooking():- " + strponse);
                _bookingReqDataRs = JsonConvert.DeserializeObject<Models.Book.BookingReqDataRs>(strponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Error While fetching booking request info from DB hotel/Booking/  on WebApiCall-> GetBookingRq:");

            }
            return _bookingReqDataRs;
        }
    }
}
