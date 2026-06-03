namespace Data.GetMeRoom.Models
{
    public class PhonePayInitRS
    {
        public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string merchantId { get; set; }
        public string merchantTransactionId { get; set; }
        public Instrumentresponse instrumentResponse { get; set; }
    }

    public class Instrumentresponse
    {
        public string type { get; set; }
        public Redirectinfo redirectInfo { get; set; }
    }

    public class Redirectinfo
    {
        public string url { get; set; }
        public string method { get; set; }
    }


}
