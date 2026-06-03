namespace Data.GetMeRoom.Models.PreBookRequest
{
    public class PreBookRQ
    {
        public Prebookrequest PreBookRequest { get; set; }
    }

    public class Prebookrequest
    {
        public string SessionId { get; set; }
        public string HotelCode { get; set; }
        public string Token { get; set; }
        public string RateCode { get; set; }
    }

}
