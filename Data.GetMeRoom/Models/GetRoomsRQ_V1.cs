using Data.GetMeRoom.Models.Search;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Detail
{
    public class GetRoomsRQ_V1
    {
        public string hotel_city_code { get; set; }
        public string checkin_date { get; set; }
        public string checkout_date { get; set; }
        public List<room_details> room_details { get; set; }
        public string currency { get; set; }

        public hotel_reference hotel_reference { get; set; }
    }
    public class hotel_reference
    {
        public string chain_code { get; set; }
        public string hotel_code { get; set; }
        public string hotel_code_context { get; set; }
        public string provider_name { get; set; }
    }
}
