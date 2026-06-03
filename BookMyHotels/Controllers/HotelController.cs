using Business.GetMeRoom;
using Data.GetMeRoom;
using Data.GetMeRoom.Models.Book;
using Data.GetMeRoom.Models.Detail;
using Data.GetMeRoom.Models.PreBook;
using Data.GetMeRoom.Models.Search;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using static Data.GetMeRoom.GlobalConstant;

namespace GetMeRoom.Controllers
{
    public class HotelController : Controller
    {
        string guid = string.Empty;
        private BusinessAPICall businessAPICall = null;
        public readonly Logger Log = LogManager.GetCurrentClassLogger();
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchResult()
        {
            SearchRS_V1 searchRS = new SearchRS_V1();
            searchRS = (SearchRS_V1)Session["searchRS"];
            // Log.Info("Search Response on ActionResult SearchResult():- " + JsonConvert.SerializeObject(searchRS));
            return View(searchRS);
        }

        [HttpGet]
        public ActionResult HotelDetail()
        {
            GetRoomsRS_V1 getRoomRS = (GetRoomsRS_V1)Session["getRoomRS"];
            return View(getRoomRS);
        }

        [HttpPost]
        public ActionResult HotelDetail(string HotelCode, string HotelProviderId, string HotelCodeContext, string ChainCode)
        {
            guid = Convert.ToString(Session["guid"]);
            SearchRQ_V1 searchRQ = new SearchRQ_V1();
            searchRQ = (SearchRQ_V1)Session["searchRequest"];

            GetRoomsRQ_V1 getRoomRQ = new GetRoomsRQ_V1();
            //  hotel_get_room hotel_get_rooms = new hotel_get_room();
            getRoomRQ.hotel_city_code = searchRQ.hotel_city_code;
            getRoomRQ.checkin_date = searchRQ.checkin_date;
            getRoomRQ.checkout_date = searchRQ.checkout_date;
            getRoomRQ.currency = searchRQ.currency;
            getRoomRQ.room_details = searchRQ.room_details;

            hotel_reference hotel_references = new hotel_reference();
            hotel_references.chain_code = ChainCode;
            hotel_references.hotel_code = HotelCode;
            hotel_references.hotel_code_context = HotelCodeContext;
            hotel_references.provider_name = HotelProviderId;
            getRoomRQ.hotel_reference = hotel_references;
            AppLogger.LogMyRqRS("hotel_detail_RQ", guid, getRoomRQ);
            //Log.Info("HotelDetail Request on ActionResult HotelDetail():- " + JsonConvert.SerializeObject(getRoomRQ));
            businessAPICall = new BusinessAPICall();
            GetRoomsRS_V1 getRoomRS = businessAPICall.HotelDetail(getRoomRQ);
            AppLogger.LogMyRqRS("hotel_detail_RS", guid, getRoomRS);
            Session["getRoomRS"] = getRoomRS;
            Session["getRoomRQ"] = getRoomRQ;
            //Log.Info("HotelDetail Response on ActionResult HotelDetail():- " + JsonConvert.SerializeObject(getRoomRS));
            return View(getRoomRS);
        }


        [HttpGet]
        public ActionResult HotelPayment()
        {
            PreBookRS_V1 _PreBook = (PreBookRS_V1)Session["PreBookRS"];
            return View(_PreBook);
        }

        [HttpPost]
        public ActionResult HotelPayment(string Token, string RateCode, string HotelCode, string RateId, string RoomId)
        {
            guid = Convert.ToString(Session["guid"]);
            GetRoomsRQ_V1 grtroom = new GetRoomsRQ_V1();
            grtroom = (GetRoomsRQ_V1)Session["getRoomRQ"];
            PreBookRQ_V1 htl_preebook = new PreBookRQ_V1();
            htl_preebook.hotel_city_code = grtroom.hotel_city_code;
            htl_preebook.checkin_date = grtroom.checkin_date;
            htl_preebook.checkout_date = grtroom.checkout_date;
            htl_preebook.currency = grtroom.currency;
            htl_preebook.token = Token;

            hotel_reference hotel_references = new hotel_reference();
            hotel_references.chain_code = grtroom.hotel_reference.chain_code;
            hotel_references.hotel_code = grtroom.hotel_reference.hotel_code;
            hotel_references.hotel_code_context = grtroom.hotel_reference.hotel_code_context;
            hotel_references.provider_name = grtroom.hotel_reference.provider_name;
            htl_preebook.hotel_reference = hotel_references;

            List<room_details> room_detailss = new List<room_details>();
            room_details room_details = new room_details();

            int adtcnt = 0;
            int chdcnt = 0;
            List<Age> Agess = new List<Age>();
            List<room_rates> Roomrates = new List<room_rates>();
            for (int i = 0; i < grtroom.room_details.Count; i++)
            {
                adtcnt += grtroom.room_details[i].adt_cnt;
                chdcnt += grtroom.room_details[i].chd_cnt;

                for (int j = 0; j < grtroom.room_details[i].chd_cnt; j++)
                {
                    //string agesss = grtroom.room_details[i].ages[j].age.ToString();
                    Age Ages = new Age();
                    Ages.age = Convert.ToInt32(grtroom.room_details[i].ages[j].age);
                    Agess.Add(Ages);
                }
            }

            room_details.adt_cnt += adtcnt;
            room_details.chd_cnt += chdcnt;
            room_details.ages = Agess;
            for (int i = 0; i < grtroom.room_details.Count; i++)
            {
                room_rates room_rate = new room_rates();
                room_rate.rate_plan_code = RateCode;
                room_rate.booking_code = RateId;
                room_rate.room_type_code = RoomId;
                Roomrates.Add(room_rate);
            }
            room_details.room_rates = Roomrates;
            room_detailss.Add(room_details);
            htl_preebook.room_details = room_detailss;
            Session["PreBookRQ"] = htl_preebook;
            AppLogger.LogMyRqRS("hotel_prebook_RQ", guid, htl_preebook);

            businessAPICall = new BusinessAPICall();
            PreBookRS_V1 _PreBook = businessAPICall.HotelPaymentMethod(htl_preebook);

            if (_PreBook?.Hotel?.Rate == null || _PreBook?.Hotel?.Rate?.Room?.Count() == 0)
            {
                string hotelDetail = AppLogger.ReadRqRS("hotel_detail_RS", guid);
                GetRoomsRS_V1 getRoomRS = Newtonsoft.Json.JsonConvert.DeserializeObject<GetRoomsRS_V1>(hotelDetail);

                var result = getRoomRS.Hotels.Hotel.Rates
    .Where(r => r.Room != null && r.Room.Any(room => room.RateId == _PreBook.ResponseInfo.BookingToken))
    .Select(r => new Data.GetMeRoom.Models.PreBook.Rate
    {
        Token = r.Token,
        RateCode = r.RateCode,
        Room = r.Room.Where(room => room.RateId == _PreBook.ResponseInfo.BookingToken).ToList()
    })
    .FirstOrDefault();

                _PreBook.Hotel.Rate = result;


            }

            AppLogger.LogMyRqRS("hotel_prebook_RS", guid, _PreBook);
            Session["PreBookRS"] = _PreBook;
            return View(_PreBook);

        }


        [HttpGet]
        public ActionResult HotelBookingProcess()
        {
            BookRS_V1 _BookRS = null;
            BookRQ_V1 bookRQ = new BookRQ_V1();
            if (GlobalConstant.ConfigVariables.ALLOWPAYMENT)
            {
                BookingReqDataRs _bookingRqDataRS = new BookingReqDataRs();
                _bookingRqDataRS = (BookingReqDataRs)Session["BookingReqDataRs"];
                if (_bookingRqDataRS != null && _bookingRqDataRS.BookRQ != null)
                {
                    bookRQ = JsonConvert.DeserializeObject<BookRQ_V1>(_bookingRqDataRS.BookRQ);
                }
            }
            else
            {
                bookRQ = (BookRQ_V1)Session["bookRQ"];
            }

            //Log.Info("Booking Request on Get ActionResult HotelBooking():- " + JsonConvert.SerializeObject(bookRQ));

            businessAPICall = new BusinessAPICall();
            try
            {
                _BookRS = businessAPICall.HotelBookMethod(bookRQ);

                if (_BookRS.bookingId == null && _BookRS.bookingStatus != "Confirmed" && _BookRS.providerConfirmationNumber == null)
                {
                    _BookRS.errorCode = 500;
                    _BookRS.errorMessage = "Unable to selected room. Request to search and rebook";
                }

                Session["BookRS"] = _BookRS;
            }
            catch (Exception ex)
            {
                Log.Error("Error While making hotel booking : " + ex.Message, "GetPaytmResponse", "GetPaytmResponse");
            }
            return RedirectToActionPermanent("HotelConfirmation");
        }


        [HttpGet]
        public ActionResult HotelConfirmation()
        {
            BookRS_V1 _BookRS = (BookRS_V1)Session["BookRS"];
            //Log.Info("Booking Response on Get ActionResult HotelBooking():- " + JsonConvert.SerializeObject(_BookRS));
            return View(_BookRS);
        }

        [HttpPost]
        public void HotelConfirmation(FormCollection collection)
        {
            guid = Convert.ToString(Session["guid"]);
            //FandHServicesClient client = new FandHServicesClient();
            //var _transactionid = client.GenerateIDs("TRN");
            // string SessionId = Convert.ToString(Session["SessionId"]);
            string Title = collection["Title_1"];
            string FirstName = collection["FirstName_1"];
            string MiddleName = collection["MiddleName_1"];
            string LastName = collection["LastName_1"];
            string Phone = collection["phoneno"];
            string Email = collection["email"];
            string Country = collection["country"];

            //List<Data.GetMeRoom.Models.Book.Room> rooms = new List<Data.GetMeRoom.Models.Book.Room>();
            PreBookRQ_V1 _PreBookRq = (PreBookRQ_V1)Session["PreBookRQ"];
            PreBookRS_V1 preBookRS = (PreBookRS_V1)Session["PreBookRS"];
            //int i = 1;

            List<Room_Details> room_Details = new List<Room_Details>();
            foreach (room_details item in _PreBookRq.room_details)
            {
                Room_Details _Details = new Room_Details
                {
                    adt_cnt = item.adt_cnt,
                    chd_cnt = item.chd_cnt,
                    ages = item.ages,
                    room_rates = new List<Room_Rates>
                    {
                        new Room_Rates {
                        booking_code = item.room_rates.First().booking_code,
                        rate_plan_code=item.room_rates.First().rate_plan_code,
                        room_type_code=item.room_rates.First().room_type_code
                        }
                    },
                    passengers = new List<Passenger> { new Passenger
                    {
                        pax_type = "ADT",
                        title = Title,
                        first_name = FirstName,
                        middle_name = MiddleName,
                        last_name = LastName,
                        phone_number = Phone,
                        email_id=Email,
                        other_phone_number="",
                        age_details=""

                    } }
                };
                room_Details.Add(_Details);
            }


            BookRQ_V1 bookRQ_V1 = new BookRQ_V1()
            {
                hotel_city_code = _PreBookRq.hotel_city_code,
                room_details = room_Details,
                passenger_address = new Passenger_Address()
                {
                    address = "123 Main St. 123 Main St.",
                    city = "New Delhi",
                    country_code = "IN",
                    zip_code = "110011"
                },
                currency = _PreBookRq.currency,
                token = _PreBookRq.token,
                hotel_reference = new Hotel_Reference()
                {
                    chain_code = _PreBookRq.hotel_reference.chain_code,
                    hotel_code = _PreBookRq.hotel_reference.hotel_code,
                    hotel_code_context = _PreBookRq.hotel_reference.hotel_code_context,
                    provider_name = _PreBookRq.hotel_reference.provider_name
                }
            };

            int totalAmount = 0;
            totalAmount = Convert.ToInt32(preBookRS.Hotel.Rate.Room.Sum(x => x.GrossPrice) * 100);

            AppLogger.LogMyRqRS("hotel_book_RQ", guid, bookRQ_V1);

            if (ConfigVariables.ALLOWPAYMENT)
            {
                if (Email.ToLower().Equals("support@findmyholidays.co.in"))
                {
                    totalAmount = 100;
                }
                PhonePeInit.InitiateGateway(guid, totalAmount);

                //Response.Redirect(ConfigVariables.SITEROOTPATH + "/TransactionProcess/PhonePe?guid="+ guid);

                //if (offerRS?.cashbackOfferId != null)
                //{

                //    if (paymentRS?.redirectUrl != null)
                //    {

                //        Response.Redirect(paymentRS?.redirectUrl);
                //    }
                //    else
                //    {
                //        Response.Redirect(GlobalConstant.ConfigVariables.SITE_ROOT_PATH + "/Hotel/Error?PayFor=ONL&BookingID=" + preBookRS.ResponseInfo.BookingToken + "&TRNID=" + _transactionid + "&Provider=" + preBookRS.Hotel.HotelCodeContext + "&uid=" + guid + "&hotel_info=" + preBookRS.Hotel.Code);
                //    }
                //}
            }
            else
            {
                Session["bookRQ"] = bookRQ_V1;
                Redirect(ConfigVariables.SITEROOTPATH + "/Hotel/Success");
                //return RedirectToActionPermanent("HotelBookingProcess");
            }
        }


        [HttpPost]
        public ActionResult FilterByName(string hotelname)
        {
            SearchRS_V1 searchRS = new SearchRS_V1();
            searchRS = (SearchRS_V1)Session["searchRS"];
            List<Data.GetMeRoom.Models.Search.Hotel> hotel = new List<Data.GetMeRoom.Models.Search.Hotel>();
            hotel = searchRS.Hotels.Hotel;
            hotel = hotel.Where(x => x.Name == hotelname).ToList();

            return PartialView("searchresult/_SearchResult", hotel.OrderBy(x => x.GrossPrice).ToList());
        }
        //02-12-2021 code end by ashish


        [HttpPost]
        public ActionResult FilterAccomodation(string[] guestrating, string[] amenities, string[] starrating, string[] ourrecom, bool IsFreeCancellation, float minfare = 0f, float maxfare = 99999f)
        {
            SearchRS_V1 searchRS = new SearchRS_V1();
            searchRS = (SearchRS_V1)Session["searchRS"];
            IList<Data.GetMeRoom.Models.Search.Hotel> hotel = new List<Data.GetMeRoom.Models.Search.Hotel>();
            hotel = searchRS.Hotels.Hotel;

            hotel = hotel.Where(x => x.GrossPrice >= minfare && x.GrossPrice <= maxfare).ToList();
            if (guestrating != null && guestrating.Length > 0)
            {
                hotel = hotel.Where(o => guestrating.Distinct().Contains(o.ReviewRating)).ToList();
            }

            //if (amenities != null && amenities.Length > 0)
            //{
            //    hotel = hotel.Where(o => o.Amenities.Any(x => amenities.Contains(Convert.ToString(x.Id)))).ToList();
            //}

            //if (starrating != null && starrating.Length > 0)
            //{
            //    hotel = hotel.Where(o => starrating.Contains(Convert.ToString(Math.Round(o.Star)))).ToList();
            //}
            if (IsFreeCancellation)
            {
                hotel = hotel.Where(o => o.IsRefundable == IsFreeCancellation).ToList();
            }
            if (ourrecom != null && ourrecom.Length > 0)
            {
                foreach (string item in ourrecom)
                {
                    if (item == "1")
                    {
                        hotel = hotel.Where(o => o.IsRecommended == true).OrderByDescending(o => o.Star).ToList();
                    }
                    else
                    {
                        hotel = hotel.Where(o => o.IsRecommended == true).OrderBy(o => o.GrossPrice).ToList();
                    }
                }


            }


            hotel = hotel.OrderBy(x => x.GrossPrice).ToList();
            return PartialView("searchresult/_SearchResult", hotel);
        }


        [HttpPost]
        public ActionResult AdditionalCharges(string Token, string RateCode)
        {
            GetRoomsRS_V1 getRoomRS = new GetRoomsRS_V1();
            getRoomRS = (GetRoomsRS_V1)Session["getRoomRS"];
            IList<AdditionalCharge> additionalCharges = new List<AdditionalCharge>();

            List<Data.GetMeRoom.Models.PreBook.Rate> result = getRoomRS.Hotels.Hotel.Rates.Where(x => x.Token == Token && x.RateCode == RateCode).ToList();
            additionalCharges = result?.FirstOrDefault().Room?.FirstOrDefault().AdditionalCharges;
            return PartialView("hoteldetails/_AdditionalCharges", additionalCharges);
        }

        [HttpPost]
        public ActionResult CancillationPolicy(string Token, string RateCode)
        {
            GetRoomsRS_V1 getRoomRS = new GetRoomsRS_V1();
            getRoomRS = (GetRoomsRS_V1)Session["getRoomRS"];
            Data.GetMeRoom.Models.PreBook.Policies policy = new Data.GetMeRoom.Models.PreBook.Policies();

            List<Data.GetMeRoom.Models.PreBook.Rate> result = getRoomRS.Hotels.Hotel.Rates.Where(x => x.Token == Token && x.RateCode == RateCode).ToList();
            policy = result?.FirstOrDefault().Room?.FirstOrDefault().Policies;
            return PartialView("hoteldetails/_CancillationPolicy", policy);
        }


        public ActionResult Success()
        {
            string guid = string.Empty, hotelCode = string.Empty, bookRq = string.Empty;
            string code = Request.Form["code"];
            string merchantId = Request.Form["merchantId"];
            guid = Request.Form["transactionId"];
            string checksum = Request.Form["checksum"];


            //code=PAYMENT_SUCCESS&
            //merchantId=PGTESTPAYUAT86&
            //transactionId=463ebf83-407e-4714-ad10-e3f936b911cf&
            //amount=10000&
            //providerReferenceId=T2406091954368553623127&
            //param1=na&
            //param2=na&
            //param3=na&
            //param4=na&
            //param5=na&
            //param6=na&
            //param7=na&
            //param8=na&
            //param9=na&
            //param10=na&
            //param11=na&
            //param12=na&
            //param13=na&
            //param14=na&
            //param15=na&
            //param16=na&
            //param17=na&
            //param18=na&
            //param19=na&
            //param20=na&
            //checksum=2ec420101ce340d500564d384adb5625accf5354bedcfa4588a9a4d915c2dbd0%23%23%231
            try
            {
                string strbookRq = AppLogger.ReadRqRS("hotel_book_RQ", guid);
                BookRQ_V1 bookRQ_V1 = JsonConvert.DeserializeObject<BookRQ_V1>(strbookRq);
                Session["bookRQ"] = bookRQ_V1;


                string preBookRs = AppLogger.ReadRqRS("hotel_prebook_RS", guid);
                PreBookRS_V1 preBookRS = JsonConvert.DeserializeObject<PreBookRS_V1>(preBookRs);
                Session["PreBookRS"] = preBookRS;



                if (ConfigVariables.ENABLE_BOOKING)
                {
                    businessAPICall = new BusinessAPICall();
                    BookRS_V1 _BookRS = businessAPICall.HotelBookMethod(bookRQ_V1);
                    AppLogger.LogMyRqRS("hotel_book_RS", guid, _BookRS);
                    Session["bookRS"] = _BookRS;
                }
                else
                {
                    BookRS_V1 bookRS_V1 = new BookRS_V1
                    {
                        bookingToken = "0J80YF0KUV_1_3T6CISAHAX3R324UXDQ2TBA0J7",
                        bookingId = "46648450",
                        bookingStatus = "Confirmed",
                        providerConfirmationNumber = "QFRC5D",
                        roomConfirmation = new List<Data.GetMeRoom.Models.Book.Roomconfirmation> {
                        new Data.GetMeRoom.Models.Book.Roomconfirmation{
                        providerConfirmationNumber="ST_1",
                        bookingStatus = "CONFIRMED",
                        rateId="LEI",
                        roomId="ROH"
                        }
                        },
                        errorCode = 0,
                        errorMessage = "",
                        rooms = new Data.GetMeRoom.Models.Book.Rooms
                        {
                            room = new List<Data.GetMeRoom.Models.Book.Room> {
                        new Data.GetMeRoom.Models.Book.Room{
                        rateId="LEI",
                        roomId="ROH",
                        roomType="******",
                        guests = new Data.GetMeRoom.Models.Book.Guests{
                        guest = new List<Data.GetMeRoom.Models.Book.Guest>{
                        new Data.GetMeRoom.Models.Book.Guest{
                        age=0,
                        firstName="Ashish",
                        lastName="Dwivedi",
                        title="MR",
                        type= "ADT"
                        }
                        }
                        }
                        }
                        }
                        }
                    };

                    Session["bookRS"] = bookRS_V1;
                }
                return RedirectToAction("HotelConfirmation");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult CallBack(HttpRequestMessage request)
        {
            var input = request.Content.ReadAsStringAsync().Result;
            var saltKey = GlobalConstant.ConfigVariables.PHONEPE_SALTKEY;
            // var saltIndex = 1;

            string orderId = Request.Form["order_id"];
            string txnId = Request.Form["txn_id"];
            string status = Request.Form["status"];
            string checksum = Request.Form["checksum"];

            //var finalXHeader = HashString("/pg/v1/status/" + input["merchantId"] + "/" + input["transactionId"] + saltKey) + "###" + saltIndex;

            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //    client.DefaultRequestHeaders.Add("accept", "application/json");
            //    client.DefaultRequestHeaders.Add("X-VERIFY", finalXHeader);
            //    client.DefaultRequestHeaders.Add("X-MERCHANT-ID", input["transactionId"]);

            //    var response = await client.GetAsync("https://api-preprod.phonepe.com/apis/merchant-simulator/pg/v1/status/" + input["merchantId"] + "/" + input["transactionId"]);
            //    var responseContent = await response.Content.ReadAsStringAsync();
            //    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
            //    Console.WriteLine(jsonResponse);
            //}
            return View(input);
        }

        public ActionResult RefundCallBack()
        {
            return View();
        }
    }
}