using Data.GetMeRoom.Models.Search;
using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Book
{

    public class BookRQ_V1
    {
        public string hotel_city_code { get; set; }
        public List<Room_Details> room_details { get; set; }
        public Passenger_Address passenger_address { get; set; }
        public string currency { get; set; }
        public Hotel_Reference hotel_reference { get; set; }
        public string token { get; set; }
    }

    public class Passenger_Address
    {
        public string address { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country_code { get; set; }
    }

    public class Hotel_Reference
    {
        public string chain_code { get; set; }
        public string hotel_code { get; set; }
        public string hotel_code_context { get; set; }
        public string provider_name { get; set; }
    }

    public class Room_Details
    {
        public int adt_cnt { get; set; }
        public int chd_cnt { get; set; }
        public IList<Age> ages { get; set; }
        public List<Room_Rates> room_rates { get; set; }
        public List<Passenger> passengers { get; set; }
    }

    //public class Age
    //{
    //    public int age { get; set; }
    //}

    public class Room_Rates
    {
        public string rate_plan_code { get; set; }
        public string booking_code { get; set; }
        public string room_type_code { get; set; }
    }

    public class Passenger
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


    public class InsertBookingDataRQ
    {
        public int Action { get; set; }
        public string TransactionId { get; set; }
        public string Token { get; set; }
        public string Product { get; set; }
        public string BookingToken { get; set; }
        public string SessionId { get; set; }
        public string BookRQ { get; set; }
    }

    public class InsertBookingDataRS
    {
        public int status { get; set; }
        public string message { get; set; }
    }
    public class BookingReqDataRs
    {
        public string BookingToken { get; set; }
        public string Product { get; set; }
        public string Token { get; set; }
        public string SessionId { get; set; }
        public string BookRQ { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
