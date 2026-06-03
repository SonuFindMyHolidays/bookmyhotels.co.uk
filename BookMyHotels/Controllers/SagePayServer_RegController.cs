using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.IO;
using Data.GetMeRoom.Models;
using EL.Payment;
using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;
using Data.GetMeRoom.Models.Book;
using Business.GetMeRoom;
using NLog;

namespace FindMyHolidays.Controllers
{
    public class SagePayServer_RegController : Controller
    {
        private BusinessAPICall businessAPICall = null;
        public readonly Logger Log = LogManager.GetCurrentClassLogger();
        public IServerPaymentResult ServerPaymentResult { get; set; }
        public IServerPayment ServerPaymentRequest { get; set; }

        // GET: SagePayServer_Reg

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SagePayserver(string PayFor, string BookingID, string TRNID, string fID, string Provider,string ProdID, string AtolAmt, string Emailid,float GrandTotal)
        {
            Data.GetMeRoom.Models.Book.BookRQ_V1 bookRQ = TempData["bookRQdata"] as Data.GetMeRoom.Models.Book.BookRQ ;
            string guid = fID;
            EL.Payment.SagePayment SagePayment = new EL.Payment.SagePayment();
            Data.GetMeRoom.Models.Book.BookRQ_V1 book = new Data.GetMeRoom.Models.Book.BookRQ_V1();
            SagePayment.PayAmount = Convert.ToDecimal((Convert.ToDecimal(GrandTotal) ).ToString("F"));

            SagePayment.NotificationUrl = "https://getmerooms.co.uk/Hotel/Notification";
            EL.Payment.Billing bill = new EL.Payment.Billing();
            EL.Payment.Shipping ship = new EL.Payment.Shipping();
            bill.Email = bookRQ.BookingRequest.BillingInfo.Email;
            bill.FirstNames = bookRQ.BookingRequest.BillingInfo.FirstName;
            bill.Phone = bookRQ.BookingRequest.BillingInfo.Phone;
            bill.Surname = bookRQ.BookingRequest.BillingInfo.LastName;
            bill.Country = "GB";
            bill.CountryName = "United Kingdom";
            SagePayment.Billing = bill;
            ship.Email = bookRQ.BookingRequest.BillingInfo.Email;
            ship.FirstNames = bookRQ.BookingRequest.BillingInfo.FirstName;
            ship.Phone = bookRQ.BookingRequest.BillingInfo.Phone;
            ship.Surname = bookRQ.BookingRequest.BillingInfo.LastName;
            ship.Country = "GB";
            ship.CountryName = "United Kingdom";
            SagePayment.Shipping = ship;

            SagePayIntegration integration = new SagePayIntegration();
            ServerPaymentRequest = integration.ServerPaymentRequest();
            SagePayment.SetServerPaymentRequestData(ServerPaymentRequest);

            ServerPaymentResult = integration.GetServerPaymentRequest(ServerPaymentRequest, SagePayment.serverPaymentUrl);
           
            if (ServerPaymentResult.Status == SagePay.IntegrationKit.ResponseStatus.OK)
            {
                businessAPICall = new BusinessAPICall();
                BookRS _BookRS = businessAPICall.HotelBookMethod(bookRQ);
                Session["BookRS"] = _BookRS;
                //string txtSearchDetails = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ServerPaymentResult);


                //string Pth = Server.MapPath(@"~\ErrorLog\" + "Pay_getmeroom" + ".txt");
                //System.IO.File.WriteAllText(Pth, txtSearchDetails);

                //for testing 

                // System.IO.File.WriteAllText(Server.MapPath(@"~\App_Data\SearchDetails\" + guid + "-path.txt"), SagePayment.NotificationUrl);
                // Response.Redirect(ServerPaymentResult.NextUrl,false);
                return Redirect(ServerPaymentResult.NextUrl);
            }
            else
            {
                //string txtSearchDetails = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ServerPaymentResult);
                //string Pth = Server.MapPath(@"~\ErrorLog\" + "Pay_getmeroom" + ".txt");
                //System.IO.File.WriteAllText(Pth, txtSearchDetails);
                //Response.Redirect(ServerPaymentResult.NextUrl, false);
                //try
                //{
                //   // _objSend.Sendcustomermail(BLL.WebsiteStaticData.EmailID1, BLL.WebsiteStaticData.EmailID1, "Online Booking (Transaction Failed)", GetTransactionFailMailBody(), "", "");
                //}
                //catch { }

                ////Miscellaneous.SetError("", ServerPaymentResult.StatusDetail);
            }
            return RedirectToAction("HotelPayment", "Hotel");
            //return View();
        }
        public string GetTransactionFailMailBody()
        {
            return "Trasaction Fail";
        }
    }
}