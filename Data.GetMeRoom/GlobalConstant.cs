using System;
using System.Configuration;

namespace Data.GetMeRoom
{
    public static class GlobalConstant
    {

        public static class ConfigVariables
        {
            public static string NATIONALITY = ConfigurationManager.AppSettings["NATIONALITY"].ToString();
            public static string CURRENCY = ConfigurationManager.AppSettings["CURRENCY"].ToString();
            public static string IP = ConfigurationManager.AppSettings["WHITLIST_IP"].ToString();
            public static string CHANNEL = ConfigurationManager.AppSettings["CHANNEL"].ToString();
            public static string AGENTID = ConfigurationManager.AppSettings["AGENTID"].ToString();
            public static string SERVICETYPE = ConfigurationManager.AppSettings["SERVICETYPE"].ToString();
            public static string AUTHKEY = ConfigurationManager.AppSettings["AUTHKEY"].ToString();

            public static string CALLUS = ConfigurationManager.AppSettings["CALLUS"].ToString();
            public static string SUPPORTE_MAIL = ConfigurationManager.AppSettings["SUPPORTE_MAIL"].ToString();
            public static string COMPANY_NAME = ConfigurationManager.AppSettings["COMPANY_NAME"].ToString();
            public static string DOMAIN_NAME = ConfigurationManager.AppSettings["DOMAIN_NAME"].ToString();
            public static string ENDPOINT = ConfigurationManager.AppSettings["ENDPOINT"].ToString();
            public static string OFFICE_ADDRESS = ConfigurationManager.AppSettings["OFFICE_ADDRESS"].ToString();


            #region PhonePe Payment Details Test Crediantials
            public static string PHONEPE_MERCHANTID = ConfigurationManager.AppSettings["PHONEPE_MERCHANTID"].ToString();
            public static string PHONEPE_SALTKEY = ConfigurationManager.AppSettings["PHONEPE_SALTKEY"].ToString();
            public static string PHONEPE_MERCHANTUSERID = ConfigurationManager.AppSettings["PHONEPE_MERCHANTUSERID"].ToString();
            public static string PHONEPE_GATEWAYURL = ConfigurationManager.AppSettings["PHONEPE_GATEWAYURL"].ToString();
            #endregion

            #region MyRegion

            #endregion
            public static string MERCHANTID = ConfigurationManager.AppSettings["MerchantId"].ToString();
            public static string MERCHANTKEY = ConfigurationManager.AppSettings["MerchantKey"].ToString();
            public static string WEBSITE = ConfigurationManager.AppSettings["Website"].ToString();
            public static string INDUSTRYTYPE = ConfigurationManager.AppSettings["IndustryType"].ToString();
            public static string CHANNELID = ConfigurationManager.AppSettings["ChannelId"].ToString();
            public static string STAGINGURL = ConfigurationManager.AppSettings["StagingUrl"].ToString();
            public static string PRODUCTIONURL = ConfigurationManager.AppSettings["ProductionUrl"].ToString();
            public static string TRANCATIONTYPE = ConfigurationManager.AppSettings["TrancationType"].ToString();
            public static string CALLBACKURL = ConfigurationManager.AppSettings["CallbackUrl"].ToString();

            public static bool ENABLE_BOOKING = Convert.ToBoolean(ConfigurationManager.AppSettings["ENABLE_BOOKING"]);
            public static bool ALLOWPAYMENT = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowPaymentGateway"]);
            public static string SITEROOTPATH = ConfigurationManager.AppSettings["SiteRootPath"].ToString();


            public static double CONVERTION_RATE = Convert.ToDouble(ConfigurationManager.AppSettings["CONVERTION_RATE"]);
        }
    }
}


