using System.Configuration;
using System.Data.SqlClient;

namespace Data.GetMeRoom
{
    public class DataConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            return Con;
        }
    }
}
