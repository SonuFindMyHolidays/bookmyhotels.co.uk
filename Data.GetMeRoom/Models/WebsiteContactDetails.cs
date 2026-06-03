using System;
using System.Web;

namespace BLL
{
    public class WebsiteStaticData
    {

        public static string ContactNo1
        {
            get
            {
                string contact1 = "0203 988 7524";


                //if (HttpContext.Current.Request.Browser.Cookies)
                //{

                //    HttpCookie nameCookie = HttpContext.Current.Request.Cookies["FT_SourceMedia"];

                //    //If Cookie exists fetch its value.
                //    string name = nameCookie != null ? nameCookie.Value.Split('=')[1] : "";
                //    if (name.ToUpper() == "FT_INTNTM")
                //    {

                //        contact1 = "0203 745 3325";
                //    }
                //    else if (name.ToUpper() == "FT_JC" || name.ToUpper() == "FT_DLCKR" || name.ToUpper() == "FT_CNF" || name.ToUpper() == "FT_CF" || name.ToUpper() == "FTT_AVNDUK")
                //    {
                //        contact1 = "0203 603 8568";
                //    }
                //}
                return contact1;

            }
        }
        public static string ContactNo2
        {
            get
            {
                string contact2 = "0203 988 7524";


                //if (HttpContext.Current.Request.Browser.Cookies)
                //{

                //    HttpCookie nameCookie = HttpContext.Current.Request.Cookies["FT_SourceMedia"];

                //    //If Cookie exists fetch its value.
                //    string name = nameCookie != null ? nameCookie.Value.Split('=')[1] : "";
                //    if (name.ToUpper() == "FT_INTNTM")
                //    {

                //        contact2 = "0203 745 3325";
                //    }
                //    else if (name.ToUpper() == "FT_JC" || name.ToUpper() == "FT_DLCKR" || name.ToUpper() == "FT_CNF" || name.ToUpper() == "FT_CF" || name.ToUpper() == "FTT_AVNDUK")
                //    {
                //        contact2 = "0203 603 8568";
                //    }
                //}
                return contact2;
            }
        }
        public static string EmailID1
        {
            get { return "sales@journeyxpert.co.uk"; }
        }

        public static string EmailID2
        {
            get { return "sales@journeyxpert.co.uk"; }
        }
        public static string WebsiteUrl
        {

            get
            {

                if (HttpContext.Current.Request.Url.Host.ToLower().Contains("localhost"))
                {


                    return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/";
                }
                else { return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/"; }

            }


        }
        public static string WebsiteUrlHTTPS
        {
            get
            {

                if (HttpContext.Current.Request.Url.Host.ToLower().Contains("localhost"))
                {


                    return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/";
                }
                else { return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/"; }

            }
        }


    }
    public static class MyEnums
    {
        #region Currency
        public struct Currency
        {
            public const String GBP = "£", INR = "₹", USD = "$", EUR = "€";
        };
        #endregion
    }
}
