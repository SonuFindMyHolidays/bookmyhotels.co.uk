using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business.GetMeRoom
{
    public static class PhonePayConfig
    {
        public static PhonePeConfigModel GetPhonePeConfig(bool IsProd)
        {
            if (IsProd)
            {
                return new PhonePeConfigModel
                {
                    PHONEPE_MERCHANTID = "M221RN4OCSPR3",
                    PHONEPE_MERCHANTUSERID = "PGTESTPAYUAT86",
                    PHONEPE_SALTKEY = "de346286-54b0-4c23-a502-e7846951f403",
                    PHONEPE_GATEWAYURL = "https://api.phonepe.com/apis/hermes",
                    PHONEPE_CHECK_STATUSURL= "https://api.phonepe.com/apis/hermes/pg/v1/status/"//https://api.phonepe.com/apis/hermes/pg/v1/status/{merchantId}/{merchantTransactionId}
                };
            }

            else
            {
                return new PhonePeConfigModel
                {
                    PHONEPE_MERCHANTID = "PGTESTPAYUAT86",
                    PHONEPE_MERCHANTUSERID = "PGTESTPAYUAT86",
                    PHONEPE_SALTKEY = "de346286-54b0-4c23-a502-e7846951f403",
                    PHONEPE_GATEWAYURL = "https://api-preprod.phonepe.com/apis/pg-sandbox",
                    PHONEPE_CHECK_STATUSURL = "https://api.phonepe.com/apis/hermes/pg/v1/status/"
                };
            }
        }


        public class PhonePeConfigModel
        {
            public string PHONEPE_MERCHANTID { get; set; }
            public string PHONEPE_MERCHANTUSERID { get; set; }
            public string PHONEPE_SALTKEY { get; set; }
            public string PHONEPE_GATEWAYURL { get; set; }
            public string PHONEPE_CHECK_STATUSURL { get; set; }
        }
    }
}
