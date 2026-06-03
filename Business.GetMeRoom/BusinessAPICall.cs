using Data.GetMeRoom;
using Data.GetMeRoom.Models;
using Data.GetMeRoom.Models.Book;
using Data.GetMeRoom.Models.Detail;
using Data.GetMeRoom.Models.PreBook;
using Data.GetMeRoom.Models.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using static Data.GetMeRoom.GlobalConstant;

namespace Business.GetMeRoom
{
    public class BusinessAPICall
    {
        private string SiteRootPath = ConfigVariables.SITEROOTPATH;
        public List<Location> GetLocation(string strLocation)
        {
            return WebApiCall.GetLocation(strLocation).Result;
        }

        public List<Location> GetAutoCompleteData(string prefix)
        {
            //IL_02ef: Unknown result type (might be due to invalid IL or missing references)
            //IL_02f6: Expected O, but got Unknown
            //IL_0099: Unknown result type (might be due to invalid IL or missing references)
            //IL_00a0: Expected O, but got Unknown
            List<Location> list = new List<Location>();
            ObjectCache @default = (ObjectCache)(object)MemoryCache.Default;
            if (@default.Contains("AirportsData", (string)null))
            {
                list = (List<Location>)@default.Get("AirportsData", (string)null);
                return list.Where((Location x) => x.PropertyName.ToLower().Contains(prefix) || x.PropertyName.StartsWith(prefix) || x.CityName.ToLower().StartsWith(prefix) || x.CityName.ToLower().Contains(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().Contains(prefix)).ToList();
            }
            DataTable dataTable = AutoCompleteAirportV1(prefix);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int num = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    Location val = new Location();
                    val.PropertyName = row["LocationDisplay"].ToString();
                    val.CityName = row["City"].ToString();
                    val.StateName = row["State"].ToString();
                    val.CountryName = row["Country"].ToString();
                    val.Code = row["Code"].ToString();
                    val.Type = row["Type"].ToString();
                    if (row["Type"].ToString().Trim() == "Location")
                    {
                        val.RawString = "<div id='ui-id-" + num + "' tabindex='-1' class='ui-menu-item-wrapper'><div class='icon-box'><i class='icon-size'><img src = '" + SiteRootPath + "/images/hotel_ico.svg'/></i></div><div class='suggestions-text'><span class='suggestions-match'>" + row["LocationDisplay"].ToString() + " (" + row["City"].ToString() + ") </span><div class='searchCountry'>" + row["State"].ToString() + "</div></div><div class='iata-wrapper'> <span class='suggestions-iata'>" + row["Country"].ToString() + "</span> </div></div>";
                    }
                    else
                    {
                        val.RawString = "<div id='ui-id-" + num + "' tabindex='-1' class='ui-menu-item-wrapper'><div class='icon-box'><i class='icon-size'><img src = '" + SiteRootPath + "/images/flighs_ico.svg'/></i></div><div class='suggestions-text'><span class='suggestions-match'>" + row["LocationDisplay"].ToString() + " (" + row["City"].ToString() + ") </span><div class='searchCountry'>" + row["State"].ToString() + "</div></div><div class='iata-wrapper'> <span class='suggestions-iata'>" + row["Country"].ToString() + "</span> </div></div>";
                    }
                    list.Add(val);
                    num++;
                }
            }
            CacheItemPolicy val2 = new CacheItemPolicy();
            val2.AbsoluteExpiration = DateTime.Now.AddHours(24.0);
            @default.Add("AirportsData", (object)list, val2, (string)null);

           var filter = list.Where(x=>x.PropertyName.ToLower().Contains(prefix) || x.PropertyName.StartsWith(prefix) || x.CityName.ToLower().StartsWith(prefix) || x.CityName.ToLower().Contains(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().Contains(prefix)).ToList();

            return list.Where((Location x) => x.PropertyName.ToLower().Contains(prefix) || x.PropertyName.StartsWith(prefix) || x.CityName.ToLower().StartsWith(prefix) || x.CityName.ToLower().Contains(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.StateName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().StartsWith(prefix) || x.CountryName.ToLower().Contains(prefix)).ToList();
        }

        public static DataTable AutoCompleteAirportV1(string Prefix)
        {
            string commandText = "select LocationDisplay, City, [State], Country,\r\nCASE \r\nWhen IsAirport IS NULL THEN 'Location'\r\nELSE 'Airport'\r\nEND AS 'Type', Code from [dbo].[tbl_autofill_data] (NOLOCK) where CountryCode='IN'";
            _ = new SqlParameter[1];
            try
            {
                if (!string.IsNullOrEmpty(Prefix))
                {
                    SqlConnection connection = DataConnection.GetConnection();
                    try
                    {
                        return SqlHelper.ExecuteDataset(connection, CommandType.Text, commandText).Tables[0];
                    }
                    finally
                    {
                        ((IDisposable)connection)?.Dispose();
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SearchRS_V1 HotelSearch(SearchRQ_V1 _searchRequest)
        {
            //return CurrencyConveraion.ConvertCurrencyListing(WebApiCall.HotelSearch(_searchRequest));
            return WebApiCall.HotelSearch(_searchRequest);
        }

        public GetRoomsRS_V1 HotelDetail(GetRoomsRQ_V1 getRoomRQ)
        {
            // return CurrencyConveraion.ConvertCurrencyDetail(WebApiCall.HotelDetail(getRoomRQ));
            return WebApiCall.HotelDetail(getRoomRQ);
        }

        public PreBookRS_V1 HotelPaymentMethod(PreBookRQ_V1 preBookRQ)
        {
            return WebApiCall.HotelPaymentMethod(preBookRQ);
        }

        public BookRS_V1 HotelBookMethod(BookRQ_V1 BookRQ)
        {
            return WebApiCall.HotelBookMethod(BookRQ);
        }


        public PaymentResponseViewModelRs SavePaytmPaymentResponse(PaymentResponseViewModel model)
        {
            return WebApiCall.SavePaytmPaymentResponse(model);
        }


        public Data.GetMeRoom.Models.Book.InsertBookingDataRS InsertBookingRq(Data.GetMeRoom.Models.Book.InsertBookingDataRQ model)
        {
            return WebApiCall.InsertBookingRq(model);
        }

        public Data.GetMeRoom.Models.Book.BookingReqDataRs GetBookingRq(Data.GetMeRoom.Models.Book.InsertBookingDataRQ model)
        {
            return WebApiCall.GetBookingRq(model);
        }
    }
}
