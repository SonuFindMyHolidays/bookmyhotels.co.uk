using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Search
{
    public class SearchRQ
    {
        public SearchRequest SearchRequest { get; set; }
    }

    public class SearchRequest
    {
        public Master Master { get; set; }
        public Authentication Authentication { get; set; }
        public Filter Filter { get; set; }
        public Rooms Rooms { get; set; }
    }

    public class Master
    {
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string CurrencyCode { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string NationalityCode { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
    }

    public class Authentication
    {
        public string Channel { get; set; }
        public string AgentId { get; set; }
        public string AuthKey { get; set; }
        public string ServiceType { get; set; }
    }

    public class Filter
    {
        public string StarRating { get; set; }
        public string HotelName { get; set; }
        public bool OnRequest { get; set; }
        public bool HotelDesc { get; set; }
        public string HotelCode { get; set; }
    }

    public class Rooms
    {
        public List<Room> Room { get; set; }
    }

    public class Room
    {
        public int Adult { get; set; }
        public Child Child { get; set; }
    }

    public class Child
    {
        public List<int> Age { get; set; }
    }


    public class SearchFormRequest {
        public string destination { get; set; }
        public string destCode { get; set; }
        public string daterange { get; set; }
        public Rooms Rooms { get; set; }
        public string roomInfo { get; set; }
    }
}
