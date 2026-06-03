using Business.GetMeRoom;
using Data.GetMeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetMeRoom.Controllers
{
    public class SuggestController : Controller
    {
        private BusinessAPICall businessAPICall=null;
        //public APIController(BusinessAPICall _businessAPICall)
        //{
        //    businessAPICall = _businessAPICall;
        //}
        // GET: API
        public JsonResult autosuggest(string location)
        {
            businessAPICall = new BusinessAPICall();
            List<Location> locations = new List<Location>();
            //locations = businessAPICall.GetLocation(location);
            locations = businessAPICall.GetAutoCompleteData(location);
            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}