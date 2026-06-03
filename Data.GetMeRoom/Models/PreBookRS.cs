using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.PreBookResponse
{

    public class PreBookRS
    {
        public Responseinfo ResponseInfo { get; set; }
        public Hotel Hotel { get; set; }
    }

    public class Responseinfo
    {
        public object ResponseId { get; set; }
        public string Currency { get; set; }
        public int Nights { get; set; }
        public bool IsBookable { get; set; }
        public bool IsPriceChanged { get; set; }
        public bool IsSoldOut { get; set; }
        public string Token { get; set; }
        public string BookingToken { get; set; }
        public string RateCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalAdult { get; set; }
        public int TotalChild { get; set; }
        public int TotalRooms { get; set; }
        public object ErrorCode { get; set; }
        public object ErrorMessage { get; set; }
    }

    public class Hotel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public object City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public object Email { get; set; }
        public string Star { get; set; }
        public string Image { get; set; }
        public object MinPrice { get; set; }
        public object Offer { get; set; }
        public Rate Rate { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewCount { get; set; }
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
        public float NetPrice { get; set; }
        public string NetCurrency { get; set; }
        public float GrossPrice { get; set; }
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
        public object ProviderHotelCode { get; set; }
        public string RateType { get; set; }
        public object Images { get; set; }
        public List<Bed> Beds { get; set; }
        public List<Dailyrate> DailyRates { get; set; }
        public List<Tax> Taxes { get; set; }
        public Policies Policies { get; set; }
        public List<AdditionalCharges> AdditionalCharges { get; set; }
        public object Notes { get; set; }
    }
    public class AdditionalCharges
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public string Unit { get; set; }
        public float Amount { get; set; }
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
        public float EstimatedValue { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class Bed
    {
        public string Type { get; set; }
        public int Count { get; set; }
    }

    public class Dailyrate
    {
        public float NetPrice { get; set; }
        public float GrossPrice { get; set; }
        public DateTime Date { get; set; }
        public bool TaxIncluded { get; set; }
    }

    public class Tax
    {
        public float NetPrice { get; set; }
        public float GrossPrice { get; set; }
        public string Description { get; set; }
    }


}
