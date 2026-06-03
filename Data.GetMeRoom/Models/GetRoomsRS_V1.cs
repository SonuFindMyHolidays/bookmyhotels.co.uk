using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Detail
{
    public class GetRoomsRS_V1
    {
        public string ResponseInfo { get; set; }
        public Hotels Hotels { get; set; }
    }
    public class Hotels
    {
        public Hotel Hotel { get; set; }
    }
    public class Hotel
    {
        public List<Models.PreBook.Rate> Rates { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string ChainCode { get; set; }
        public string HotelCityCode { get; set; }
        public string HotelCodeContext { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<Description> Descriptions { get; set; }
        public string Neighbourhoods { get; set; }
        public List<Nearbyattraction> NearByAttractions { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<Image> Images { get; set; }
        public string Star { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewCount { get; set; }
        public string Image { get; set; }
        public double MinPrice { get; set; }
        public object Offer { get; set; }
    }

    public class Rate
    {
        public string Token { get; set; }
        public string RateCode { get; set; }
        public List<Room> Room { get; set; }
    }

    public class Room
    {
        public string RateId { get; set; }
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public string RoomDesc { get; set; }
        public string BoardBasis { get; set; }
        public object Rooms { get; set; }
        public bool Avl { get; set; }
        public double NetPrice { get; set; }
        public string NetCurrency { get; set; }
        public double GrossPrice { get; set; }
        public string GrossCurrency { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }
        public bool NeedsPriceCheck { get; set; }
        public bool IsPackageRate { get; set; }
        public bool IsRefundable { get; set; }
        public bool PayAtHotel { get; set; }
        public bool SmokingAllowed { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public string ChildAge { get; set; }
        public List<Occupancy> Occupancy { get; set; }
        public string ProviderHotelCode { get; set; }
        public string RateType { get; set; }
        public List<Image> Images { get; set; }
        public List<Bed> Beds { get; set; }
        public List<Dailyrate> DailyRates { get; set; }
        public List<RoomTaxes> Taxes { get; set; }
        //public List<Tax> Taxes { get; set; }
        public Policies Policies { get; set; }
        public List<AdditionalCharges> AdditionalCharges { get; set; }
        public string Notes { get; set; }


    }

    public class RoomTaxes
    {
        public string Type { get; set; }
        public string text { get; set; }
    }

    public class AdditionalCharges
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

    }
    public class Policies
    {
        public List<Policy> Policy { get; set; }
    }
    public class Policy
    {
        public string Value { get; set; }
        public string ValueType { get; set; }
        public double EstimatedValue { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
    public class Image
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Size { get; set; }
    }

    public class Bed
    {
        public string Type { get; set; }
        public int Count { get; set; }
    }

    public class Dailyrate
    {
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public string Date { get; set; }
        public bool TaxIncluded { get; set; }
    }
    public partial class Occupancy
    {

        public long NumOfAdults { get; set; }

        public long NumOfChildren { get; set; }


        public object ChildAges { get; set; }
    }
    public class Tax
    {
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public string Description { get; set; }
    }

    public class Description
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }

    public class Nearbyattraction
    {
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Unit { get; set; }
    }

    public class Facility
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Amenity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Ity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
