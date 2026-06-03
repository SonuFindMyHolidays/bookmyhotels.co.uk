namespace Data.GetMeRoom.Models.Detail
{
    public class GetRoomRQ
    {
        public RoomRequest roomRequest { get; set; }
    }

    public class RoomRequest
    {
        public string SessionId { get; set; }
        public string ProviderIds { get; set; }
        public string HotelCode { get; set; }
        public string Token { get; set; }
    }

}
