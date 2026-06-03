using Data.GetMeRoom.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;

namespace Data.GetMeRoom
{
    public static class DB_Repository
    {
        private const string AirportsDataKay = "AirportsData";
        public static List<Location> GetAutoCompleteData(string prefix)
        {
            List<Location> result = new List<Location>();

            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(AirportsDataKay))
            {
                result = (List<Location>)cache.Get(AirportsDataKay);
                result = result.Where(x => x.Name.ToLower().StartsWith(prefix) || x.Name.ToLower().Contains(prefix) || x.CountryCode.ToLower().StartsWith(prefix) || x.CountryCode.ToLower().Contains(prefix) || x.CountryName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().Contains(prefix)).ToList();
                return result;
            }
            else
            {

                DataTable dt = AutoCompleteAirport(prefix);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Location locresult = new Location();
                        locresult.Code = dr["Airport_Name"].ToString();
                        locresult.Name = dr["City_Name"].ToString();
                        locresult.CountryCode = dr["Airport_Code"].ToString();
                        locresult.CountryName = dr["Country_Name"].ToString();
                        locresult.Type = "";
                        result.Add(locresult);
                    }
                }

                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(24.0);
                cache.Add(AirportsDataKay, result, cacheItemPolicy);
            }
            result = result.Where(x => x.Name.Contains(prefix) || x.CountryCode.Contains(prefix) || x.CountryName.Contains(prefix)).ToList();
            return result;
        }

        public static DataTable AutoCompleteAirport(string Prefix)
        {
            string AirportQuery = "SELECT City_Name ,Airport_Name,Airport_Code,Country_Code ,Country_Name  ,City_Code FROM Airport_Details (NOLOCK)  WHERE This_Status = 1";
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                if (!string.IsNullOrEmpty(Prefix))
                {
                    using (SqlConnection conection = DataConnection.GetConnection())
                    {
                        DataSet ds = SqlHelper.ExecuteDataset(conection, CommandType.Text, AirportQuery);
                        return ds.Tables[0];
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
