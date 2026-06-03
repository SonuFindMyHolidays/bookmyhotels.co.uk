using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Search
{
    public class SearchRS_V1
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

        public List<Rate> Rates { get; set; }
        public long ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ChainCode { get; set; }
        public string HotelCodeContext { get; set; }
        public string Address { get; set; }
        public string HotelDesc { get; set; }
        public string Star { get; set; }
        public string Image { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double NetPrice { get; set; }
        public string NetCurrency { get; set; }
        public double GrossPrice { get; set; }
        public string GrossCurrency { get; set; }
        public string Offer { get; set; }
        public string ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string Token { get; set; }
        public string EssentialInfo { get; set; }
        public bool PayAtHotel { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsFreeCancellation { get; set; }
        public bool IsRefundable { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewCount { get; set; }
        // public List<Amenity> Amenities { get; set; }
        public List<Facilities> Facilities { get; set; }
    }


    public class Amenity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Facilities
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Rate
    {
        public string Token { get; set; }
        public string RateCode { get; set; }
        public List<RoomSerchRS> Room { get; set; }
    }

    public class RoomSerchRS
    {

        public string RateId { get; set; }
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public string RoomDesc { get; set; }
        public string BoardBasis { get; set; }
        public bool Avl { get; set; }
        public double NetPrice { get; set; }
        public string NetCurrency { get; set; }
        public bool IsRefundable { get; set; }
        public List<Amenity> TotalAmenities { get; set; }
        public RoomPolicies RoomPolicies { get; set; }
        public string RoomFacilityDesc { get; set; }
        public List<RoomTypeImage> RoomTypeImages { get; set; }
    }

    public class RoomPolicies
    {

        public DateTime CheckInTime { get; set; } = DateTime.Now;

        public DateTime CheckOutTime { get; set; } = DateTime.Now;


        public List<Description> Description { get; set; }
    }

    public class Description
    {
        public string PolicyInfo { get; set; }
    }

    public class RoomTypeImage
    {
        public string Image { get; set; }
    }


}
