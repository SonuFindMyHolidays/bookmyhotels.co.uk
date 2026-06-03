using System;
using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Book
{
    public class BookRQ
    {
        public Bookingrequest BookingRequest { get; set; }
    }

    public class Bookingrequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
        public string RateCode { get; set; }
        public string BookingToken { get; set; }
        public string HotelCode { get; set; }
        public Bookinginfo BookingInfo { get; set; }
        public Billinginfo BillingInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public Rooms Rooms { get; set; }
    }

    public class Bookinginfo
    {
        public string ClientRefNo { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
    }

    public class Billinginfo
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }

    public class PaymentInfo
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string ExpiryYear { get; set; }
        public string ExpiryMonth { get; set; }
        public string cvv { get; set; }
    }

    public class Rooms
    {
        public List<Room> Room { get; set; }
    }

    public class Room
    {
        public string RateId { get; set; }
        public string RoomId { get; set; }
        public Guests Guests { get; set; }
    }

    public class Guests
    {
        public List<Guest> Guest { get; set; }
    }

    public class Guest
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
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
