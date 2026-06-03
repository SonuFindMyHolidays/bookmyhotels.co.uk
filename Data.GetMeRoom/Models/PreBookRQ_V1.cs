using Data.GetMeRoom.Models.Detail;
using Data.GetMeRoom.Models.Search;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.PreBook
{
    public class PreBookRQ_V1
    {
        public string hotel_city_code { get; set; }
        public string checkin_date { get; set; }
        public string checkout_date { get; set; }
        public List<room_details> room_details { get; set; }
        public string currency { get; set; }

        public hotel_reference hotel_reference { get; set; }
        public string token { get; set; }
    }
}
