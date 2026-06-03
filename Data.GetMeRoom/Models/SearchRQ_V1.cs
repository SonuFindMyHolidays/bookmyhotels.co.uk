using Data.GetMeRoom.Models.Book;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Search
{
    public class SearchRQ_V1
    {
        public string hotel_city_code { get; set; }
        public string checkin_date { get; set; }
        public string checkout_date { get; set; }
        public List<room_details> room_details { get; set; }
        public string currency { get; set; }
    }
    public class room_details
    {
        public int adt_cnt { get; set; }
        public int chd_cnt { get; set; }
        public List<Age> ages { get; set; }
        public List<room_rates> room_rates { get; set; }
    }

    public class passengers
    {
        public string pax_type { get; set; }
        public string title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string age_details { get; set; }
        public string phone_number { get; set; }
        public string other_phone_number { get; set; }
        public string email_id { get; set; }

    }

    public class Age
    {
        public int age { get; set; }

    }

    public class room_rates
    {
        public string rate_plan_code { get; set; }
        public string booking_code { get; set; }
        public string room_type_code { get; set; }

    }

    public class SearchFormRequest
    {
        public string destination { get; set; }
        public string destCode { get; set; }
        public string daterange { get; set; }
        public Rooms Rooms { get; set; }
        public string roomInfo { get; set; }
        public int roomCount { get; set; }
        public List<room_details> room_details { get; set; }
    }

    //public class Rooms
    //{
    //    public List<Room> Room { get; set; }
    //}

    //public class Room
    //{
    //    public int Adult { get; set; }
    //    public Child Child { get; set; }
    //}
    //public class Child
    //{
    //    public List<int> Age { get; set; }
    //}
}
