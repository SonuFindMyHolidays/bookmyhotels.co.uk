using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Search
{
    public class SearchRS
    {
        public object ResponseInfo { get; set; }
        public Hotels Hotels { get; set; }
    }

    public class Hotels
    {
        public List<Hotel> Hotel { get; set; }
    }

    public class Hotel
    {
        public string ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotelDesc { get; set; }
        public double Star { get; set; }
        public string Image { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public float NetPrice { get; set; }
        public string NetCurrency { get; set; }
        public float GrossPrice { get; set; }
        public string GrossCurrency { get; set; }
        public string Offer { get; set; }
        public string ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string Token { get; set; }
        public object EssentialInfo { get; set; }
        public bool PayAtHotel { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsFreeCancellation { get; set; }
        public bool IsRefundable { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewCount { get; set; }
        public List<Amenity> Amenities { get; set; }
    }

    public class Amenity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


}
