using Data.GetMeRoom.Models.Detail;
using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.PreBook
{
    public class PreBookRS_V1
    {
        public Responseinfo ResponseInfo { get; set; }
        public Hotel Hotel { get; set; }
    }
    public class Responseinfo
    {
        public long ResponseId { get; set; }
        public string Currency { get; set; }
        public long Nights { get; set; }
        public bool IsBookable { get; set; }
        public bool IsPriceChanged { get; set; }
        public bool IsSoldOut { get; set; }
        public string Token { get; set; }
        public string BookingToken { get; set; }
        public string RateCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public long TotalAdult { get; set; }
        public long TotalChild { get; set; }
        public long TotalRooms { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class Hotel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ChainCode { get; set; }
        public string HotelCityCode { get; set; }
        public string HotelCodeContext { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<Tion> Descriptions { get; set; }
        public string Neighbourhoods { get; set; }
        public List<NearByAttraction> NearByAttractions { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<Image> Images { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Star { get; set; }
        public string Image { get; set; }
        public string MinPrice { get; set; }
        public string Offer { get; set; }
        public Rate Rate { get; set; }
        public string ReviewRating { get; set; }
        public long ReviewCount { get; set; }
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

    public class Tion
    {

        public string Type { get; set; }
        public string Text { get; set; }
    }

    public class Image
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Size { get; set; }
    }

    public class NearByAttraction
    {

        public string Name { get; set; }
        public string Distance { get; set; }
        public string Unit { get; set; }
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
        public string Rooms { get; set; }
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
        public bool AllGuestsInfoRequired { get; set; }
        public long Adult { get; set; }
        public long Child { get; set; }
        public string ChildAge { get; set; }
        public string ProviderHotelCode { get; set; }
        public string RateType { get; set; }
        public List<Image> Images { get; set; }
        public List<Bed> Beds { get; set; }
        public List<DailyRate> DailyRates { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<AdditionalCharge> AdditionalCharges { get; set; }
        //public List<RoomTaxes> Taxes { get; set; }
        public Policies Policies { get; set; }
        public List<Tion> EssentialInformation { get; set; }
        public List<AllowedCreditCard> AllowedCreditCards { get; set; }
    }
    public class AdditionalCharge
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }

    public class AllowedCreditCard
    {
        public string Type { get; set; }
        public string Code { get; set; }
    }

    public class Bed
    {
        public string Type { get; set; }
        public long Count { get; set; }
    }

    public class DailyRate
    {
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public string Date { get; set; }
        public bool TaxIncluded { get; set; }
    }

    public class Policies
    {
        public List<Policy> Policy { get; set; }
    }

    public class Policy
    {
        public double Value { get; set; }
        public string ValueType { get; set; }
        public double EstimatedValue { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class Tax
    {
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public string Description { get; set; }
    }
}
