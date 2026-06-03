using Business.GetMeRoom;
using Data.GetMeRoom;
using Data.GetMeRoom.Models;
using Data.GetMeRoom.Models.Search;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace GetMeRoom.Controllers
{

    public class HomeController : Controller
    {
        public readonly Logger Log = LogManager.GetCurrentClassLogger();
        private BusinessAPICall businessAPICall = null;
        string currency = string.Empty;
        string country = string.Empty;
        public HomeController()
        {
            if(GlobalConstant.ConfigVariables.CURRENCY=="INR")
            {
                country = "India’s";
            }
            else
            {
                country = "England's";
            }
            
        }
        public ActionResult Index()
        {
            ViewBag.Title= $"{country} Cheapest Hotel Booking Platform | Book My Hotels";

            ViewBag.MetaDescription = $"Book My Hotels is {country} Cheapest Hotel Booking Platform. Search and explore budget, family, and luxury hotels across major {country} cities in one place.";

            ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/";     //"https://www.bookmyhotels.co.in/";
            return View();
        }

        

        public ActionResult HotelSearch(FormCollection formCollection)
        {
            try
            {
                string location = formCollection.Get("location");
                string hdnlocation = formCollection.Get("hdnlocation");
                string datepicker = formCollection.Get("datepicker");
                if (string.IsNullOrEmpty(datepicker))
                {
                    datepicker = formCollection.Get("hdndate");
                }
                int TotalRooms = Convert.ToInt32(formCollection.Get("hdnrooms"));
                string[] checkinDate = datepicker.Split('-')[0].Trim().Insert(6, "20").Split('/');
                string[] checkOutDate = datepicker.Split('-')[1].Trim().Insert(6, "20").Split('/');

                DateTime Checkin = DateTime.ParseExact(checkinDate[0] + "/" + checkinDate[1] + "/" + checkinDate[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime CheckOut = DateTime.ParseExact(checkOutDate[0] + "/" + checkOutDate[1] + "/" + checkOutDate[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int NoofNight = (CheckOut - Checkin).Days;
                Session["TotalNights"] = NoofNight;
                SearchRQ_V1 _hotelsearch = new SearchRQ_V1();
                _hotelsearch.checkin_date = Checkin.ToString("yyyy-MM-dd");
                _hotelsearch.checkout_date = CheckOut.ToString("yyyy-MM-dd");
                _hotelsearch.hotel_city_code = hdnlocation;
                List<room_details> H_RoomDetails = new List<room_details>();
                for (int i = 0; i < TotalRooms; i++)
                {

                    room_details roomretail = new room_details();
                    roomretail.adt_cnt = Convert.ToInt32(formCollection.Get("room-" + (i + 1) + "-adults"));
                    roomretail.chd_cnt = Convert.ToInt32(formCollection.Get("room-" + (i + 1) + "-childs"));

                    List<Age> Agess = new List<Age>();

                    for (int j = 0; j < roomretail.chd_cnt; j++)
                    {
                        Age Ages = new Age();
                        Ages.age = Convert.ToInt32(formCollection.Get("room-" + (i + 1) + "-child-" + (j + 1) + "-age"));
                        Agess.Add(Ages);
                    }
                    roomretail.ages = Agess;
                    H_RoomDetails.Add(roomretail);
                }
                _hotelsearch.room_details = H_RoomDetails;
                _hotelsearch.currency = GlobalConstant.ConfigVariables.CURRENCY;
                Session["SessionId"] = CommonMethods.GenerateTokenID();
                Session["searchRequest"] = _hotelsearch;
                Session["location"] = location;
                Session["traveldate"] = datepicker;

                SetVariableforModify(_hotelsearch);

                return RedirectToAction("Loader");
            }
            catch
            {
                return RedirectToAction("home");
            }
        }


        public ActionResult Loader()
        {
            ViewBag.Location = Session["location"].ToString();
            return View();
        }

        public ActionResult StaticPage(string slug)
        {
            switch (slug.ToLower())
            {
                case "about-us":
                    ViewBag.Title = $"About Book My Hotels | {country} Cheapest Hotel Booking Platform";
                    ViewBag.MetaDescription = $"Book My Hotels helps you compare real hotel prices and book budget stays at the lowest available rates across {country}. Clear pricing. Smarter booking.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/about-us";
                    return View("aboutus");

                case "contact-us":
                    ViewBag.Title = "Contact Us | Book My Hotels";
                    ViewBag.MetaDescription = "Get in touch with Book My Hotels for support, questions, or booking assistance.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}";// "https://www.bookmyhotels.co.in/contact-us";
                    return View("contact-us");

                case "cookies-policy":
                    ViewBag.Title = "Cookies Policy | Book My Hotels";
                    ViewBag.MetaDescription = "Learn how Book My Hotels uses cookies to improve website functionality, performance, and user experience.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/cookies-policy";
                    return View("cookies-policy");

                case "customer-care":
                    return View("customer-care");

                case "privacy-policy":
                    ViewBag.Title = "Privacy Policy | Book My Hotels";
                    ViewBag.MetaDescription = "Review the Privacy Policy of Book My Hotels to understand how we collect, use, and protect your personal information.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/privacy-policy";
                    return View("privacy-policy");

                case "terms":
                    ViewBag.Title = "Terms & Conditions | Book My Hotels";
                    ViewBag.MetaDescription = "Read the Terms and Conditions for using Book My Hotels.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/terms-and-conditions";
                    return View("terms");

                case "best-family-friendly-hotels-in-india":
                    ViewBag.Title = "Best Family-Friendly Hotels in India | Top Family Resorts & Budget Stays – Book My Hotels";
                    ViewBag.MetaDescription = "Discover the best family-friendly hotels and resorts in India with Book My Hotels. From royal palaces in Udaipur to beach resorts in Goa and hill station retreats in Coorg — find safe, affordable, and comfortable stays for your next family vacation.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/blog/best-family-friendly-hotels-in-india";
                    return View("best-family-friendly-hotels-in-india");

                case "boutique-beach-hotels-india-romantic-getaways":
                    ViewBag.Title = "Boutique Beach Hotels in India | Romantic Seaside Getaways – Book My Hotels";
                    ViewBag.MetaDescription = "Discover the most romantic boutique beach hotels in India with Book My Hotels. From Goa and Kerala to the Andamans, explore luxury seaside resorts perfect for couples and honeymooners.";
                    ViewBag.CanonicalUrl = "https://www.bookmyhotels.co.in/blog/boutique-beach-hotels-india-romantic-getaways";
                    return View("boutique-beach-hotels-india-romantic-getaways");

                case "beachfront-bliss-best-india-hotels-with-spa-and-sea-views":
                    ViewBag.Title = "Beachfront Bliss: Best India Hotels with Spa & Sea Views | Book My Hotels";
                    ViewBag.MetaDescription = "Discover the best beachfront hotels in India with spa and sea views. From Kerala to Goa, explore romantic beach resorts and spa retreats with Book My Hotels.";
                    ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Path}"; //"https://www.bookmyhotels.co.in/blog/beachfront-bliss-best-india-hotels-with-spa-and-sea-views";
                    return View("beachfront-bliss-best-india-hotels-with-spa-and-sea-views");

                default:
                    return HttpNotFound();
            }
        }


        public ActionResult SearchHotel()
        {
            //SearchRQ searchRequest = new SearchRQ();
            SearchRQ_V1 searchRequest = new SearchRQ_V1();

            searchRequest = (SearchRQ_V1)Session["searchRequest"];
            //Log.Info("Search Request on ActionResult SearchHotel():- " + Newtonsoft.Json.JsonConvert.SerializeObject(searchRequest));

            string guid = CommonMethods.GenerateUniqueGUID();
            Session["guid"] = guid;
            AppLogger.LogMyRqRS("hotel_search_RQ", guid, searchRequest);

            //Task.Run(() => InternalLogger.LogMyRqRS("hotel_search_RQ", guid, searchRequest));

            businessAPICall = new BusinessAPICall();
            SearchRS_V1 searchRS = new SearchRS_V1();
            searchRS = businessAPICall.HotelSearch(searchRequest);

            AppLogger.LogMyRqRS("hotel_search_RS", guid, searchRS);
            //Task.Run(() => InternalLogger.LogMyRqRS("hotel_search_RS", guid, searchRS));

            //Log.Info("Search Response on ActionResult SearchHotel():- " + Newtonsoft.Json.JsonConvert.SerializeObject(searchRS));
            Session["searchRS"] = searchRS;

            var data = @"{
              ""Count"": ""10"",
              ""Customer"": ""Success""
            }";

            //return RedirectToActionPermanent("SearchResult", "Hotel", searchRequest.SearchRequest.Master.SessionId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [ActionName("about-us")]
        public ActionResult aboutus()
        {
            ViewBag.Title = $"About Book My Hotels | {country} Cheapest Hotel Booking Platform";

            ViewBag.MetaDescription = $"Book My Hotels helps you compare real hotel prices and book budget stays at the lowest available rates across {country}. Clear pricing. Smarter booking.";

            ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/"; //"https://www.bookmyhotels.co.in/about-us";
            return View();
        }

        [ActionName("contact-us")]
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us | Book My Hotels";

            ViewBag.MetaDescription = $"Get in touch with Book My Hotels for support, questions, or booking assistance. We’re here to help with your hotel search across {country}.";

            ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/";// "https://www.bookmyhotels.co.in/contact-us";
            return View();
        }
        [ActionName("cookies-policy")]
        public ActionResult CookiesPolicy()
        {
            ViewBag.Title = "Cookies Policy | Book My Hotels";

            ViewBag.MetaDescription = "Learn how Book My Hotels uses cookies to improve website functionality, performance, and user experience while browsing our platform.";

            ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/";// "https://www.bookmyhotels.co.in/cookies-policy";
            return View();
        }
        [ActionName("customer-care")]
        public ActionResult CustomerCare()
        {

            return View();
        }
        [ActionName("privacy-policy")]
        public ActionResult Privacy()
        {
            ViewBag.Title = "Privacy Policy | Book My Hotels";

            ViewBag.MetaDescription = "Review the Privacy Policy of Book My Hotels to understand how we collect, use, and protect your personal information.";

            ViewBag.CanonicalUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/"; //"https://www.bookmyhotels.co.in/privacy-policy";
            return View();
        }
        [ActionName("terms")]
        public ActionResult Terms()
        {
            ViewBag.Title = "Terms & Conditions | Book My Hotels";

            ViewBag.MetaDescription = "Read the Terms and Conditions for using Book My Hotels. Understand user responsibilities, platform usage, and booking-related policies.";

            ViewBag.CanonicalUrl = "https://www.bookmyhotels.co.in/terms-and-conditions";
            return View();
        }
        private void SetVariableforModify(SearchRQ_V1 searchRQ)
        {
            SearchFormRequest searchForm = new SearchFormRequest();
            searchForm.destCode = searchRQ.hotel_city_code;
            searchForm.destination = Convert.ToString(Session["location"]);
            searchForm.daterange = Convert.ToString(Session["traveldate"]);
            searchForm.roomCount = searchRQ.room_details.Count;

            //List<Data.GetMeRoom.Models.Search.Room> Room = new List<Data.GetMeRoom.Models.Search.Room>();
            //1|2|2-5,13~2|1|1-15

            for (int i = 0; i < searchRQ.room_details.Count; i++)
            {
                if (!string.IsNullOrEmpty(searchForm.roomInfo))
                {
                    searchForm.roomInfo += "~";
                }
                string roomInfo = Convert.ToString(i + 1) + "|" + searchRQ.room_details[i].adt_cnt + "|" + searchRQ.room_details[i].chd_cnt + "-";
                string chd = string.Empty;
                for (int j = 0; j < searchRQ.room_details[i].ages.Count; j++)
                {
                    if (string.IsNullOrEmpty(chd))
                    {
                        chd = Convert.ToString(searchRQ.room_details[i].ages[j].age);
                    }
                    else
                    {
                        chd += "," + Convert.ToString(searchRQ.room_details[i].ages[j].age);
                    }
                }
                searchForm.roomInfo += string.Concat(roomInfo, chd);
            }

            Session["searchFormRequest"] = searchForm;
        }


    }
}