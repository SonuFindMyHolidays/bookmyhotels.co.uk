using System.Collections.Generic;

namespace Data.GetMeRoom.Models.Book
{
    public class BookRS_V1
    {
        public string bookingToken { get; set; }
        public string bookingId { get; set; }
        public string bookingStatus { get; set; }
        public string providerConfirmationNumber { get; set; }
        public List<Roomconfirmation> roomConfirmation { get; set; }
        public Rooms rooms { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
    }

    public class Rooms
    {
        public List<Room> room { get; set; }
    }

    public class Room
    {
        public string rateId { get; set; }
        public string roomId { get; set; }
        public string roomType { get; set; }
        public Guests guests { get; set; }
    }

    public class Guests
    {
        public List<Guest> guest { get; set; }
    }

    public class Guest
    {
        public string type { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
    }

    public class Roomconfirmation
    {
        public string providerConfirmationNumber { get; set; }
        public string bookingStatus { get; set; }
        public string rateId { get; set; }
        public string roomId { get; set; }
    }
}
