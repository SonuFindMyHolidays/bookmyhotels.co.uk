using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Booking
{

    public class BookRS
    {
        public string BookingToken { get; set; }
        public string BookingId { get; set; }
        public string BookingStatus { get; set; }
        public string ProviderConfirmationNumber { get; set; }
        public List<Roomconfirmation> RoomConfirmation { get; set; }
        public Rooms Rooms { get; set; }
        public int ErrorCode { get; set; }
        public object ErrorMessage { get; set; }
    }

    public class Rooms
    {
        public List<Room> Room { get; set; }
    }

    public class Room
    {
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public string RateId { get; set; }
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
        public object MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public object Email { get; set; }
    }

    public class Roomconfirmation
    {
        public string ProviderConfirmationNumber { get; set; }
        public string BookingStatus { get; set; }
        public string RateId { get; set; }
        public string RoomId { get; set; }
    }


}
