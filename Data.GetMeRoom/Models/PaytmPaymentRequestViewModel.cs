namespace Data.GetMeRoom.Models
{
    public class PaytmPaymentRequestViewModel
    {
        public string PhoneNumber { get; set; }
        public string BookingID { get; set; }

        public string OrderID { get; set; }
        public string MID { get; set; }
        public decimal Amount { get; set; }
        public string Emailid { get; set; }
        public decimal GrandTotal { get; set; }

    }

    public class PaymentResponseViewModelRs
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class PaymentResponseViewModel
    {
        public string MID { get; set; }
        public string ORDERID { get; set; }
        public string TXNAMOUNT { get; set; }
        public string CURRENCY { get; set; }
        public string TXNID { get; set; }
        public string BANKTXNID { get; set; }
        public string STATUS { get; set; }
        public string RESPCODE { get; set; }
        public string RESPMSG { get; set; }
        public string TXNDATE { get; set; }
        public string GATEWAYNAME { get; set; }
        public string BANKNAME { get; set; }
        public string PAYMENTMODE { get; set; }
        public string CHECKSUMHASH { get; set; }

    }
}
