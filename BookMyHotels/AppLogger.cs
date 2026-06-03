using Newtonsoft.Json;
using NLog;
using System.IO;
using System.Web;

namespace GetMeRoom
{
    public static class AppLogger
    {
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void LogMyRqRS(string LogFor, string strGuid, object dataToWrite)
        {
            string WritableGuID = string.Empty;
            //hotel_sell_RQ_1A3B944E-3632-467B-A53A-206305310BAE
            try
            {
                WritableGuID = LogFor + "_" + strGuid;
                string content = JsonConvert.SerializeObject(dataToWrite);
                string Pth_hotel_sell_rq = HttpContext.Current.Server.MapPath(@"~\HotelLogs\" + WritableGuID + ".txt"); //HotelSearchDetails\hotel_sell_RQ
                File.WriteAllText(Pth_hotel_sell_rq, content);
            }
            catch (System.Exception ex)
            {
                Log.Info("Error While Logging " + WritableGuID + " :- " + ex.InnerException);
            }

        }

        public static string ReadRqRS(string LogFor, string strGuid)
        {
            string result = string.Empty;
            string WritableGuID = string.Empty;
            //hotel_sell_RQ_1A3B944E-3632-467B-A53A-206305310BAE
            try
            {
                WritableGuID = LogFor + "_" + strGuid;
                string Pth_hotel_sell_rq = HttpContext.Current.Server.MapPath(@"~\HotelLogs\" + WritableGuID + ".txt"); //HotelSearchDetails\hotel_sell_RQ
                if (File.Exists(Pth_hotel_sell_rq))
                {
                    result = File.ReadAllText(Pth_hotel_sell_rq);
                }
            }
            catch (System.Exception ex)
            {
                Log.Info("Error While Logging " + WritableGuID + " :- " + ex.InnerException);
            }
            return result;
        }
    }
}