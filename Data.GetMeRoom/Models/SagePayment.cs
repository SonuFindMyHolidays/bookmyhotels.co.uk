using System;
using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;

namespace EL.Payment
{
    public class SagePayment
    {
        public SagePayment()
        {
            this.PayCurrency = "GBP";

            this.PayEmail = "support@getmerooms.co.uk";

            //this.VendorName = "flightsholidays";
            //this.PayEncriptedPwd = "8e5023f6ca5abde8";

            this.VendorName = "flighttrotters";
            //this.PayEncriptedPwd = "99b6385568ad564e";
            this.PayEncriptedPwd = "0c901a13fa45d3e6";

            this.payProtocall = "3.00";
            this.PayConnectingServer = "LIVE";
            this.TransactionType = "DEFERRED";//PAYMENT
        }
        public string PayCurrency { set; get; }
        public string PayEmail { set; get; }
        public string VendorName { set; get; }
        public string PayEncriptedPwd { set; get; }
        public string payProtocall { set; get; }
        public string PayConnectingServer { set; get; }
        public decimal PayAmount { set; get; }
        public string TransactionType { set; get; }
        public string NotificationUrl { set; get; }
        public string VendorTxCode { set; get; }
        public string serverPaymentUrl
        {
            get { return "https://" + PayConnectingServer + ".sagepay.com/gateway/service/vspserver-register.vsp"; } //return "https://" + PayConnectingServer.ToLower() + ".sagepay.com/gateway/service/direct3dcallback.vsp"; }
        }
        public string directPaymentUrl
        {
            get { return "https://" + PayConnectingServer + ".sagepay.com/gateway/service/vspdirect-register.vsp"; } //return "https://" + PayConnectingServer.ToLower() + ".sagepay.com/gateway/service/direct3dcallback.vsp"; }
        }

        public EL.Payment.Billing Billing { set; get; }
        public EL.Payment.Shipping Shipping { set; get; }

        public void SetServerPaymentRequestData(IServerPayment request)
        {
            if (Billing.FirstNames == "AMIT" && Billing.Surname == "BHATT")
            {
                PayConnectingServer = "TEST";
                PayEncriptedPwd = "99b6385568ad564e";
            }

            decimal cardCharge = Convert.ToDecimal(0.02);
            request.VpsProtocol = (ProtocolVersion)Enum.Parse(typeof(ProtocolVersion), "V_" + payProtocall.Replace(".", ""));
            request.TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), TransactionType);
            request.Vendor = VendorName;
            VendorTxCode = GetNewVendorTxCode();
            request.VendorTxCode = VendorTxCode;
            request.Amount = PayAmount;
            request.Currency = PayCurrency;
            request.Description = "Booking from GetMeRooms.co.uk";
            request.BillingSurname = Billing.Surname;
            request.BillingFirstnames = Billing.FirstNames;
            request.BillingAddress1 = ".";// Billing.Address1;
            request.BillingCity = ".";// Billing.City;
            request.BillingPostCode = " ";// Billing.PostCode;
            request.BillingCountry = Billing.Country;
            request.DeliverySurname = Shipping.Surname;
            request.DeliveryFirstnames = Shipping.FirstNames;
            request.DeliveryAddress1 = ".";//  Shipping.Address1;
            request.DeliveryCity = ".";// .City;
            request.DeliveryPostCode = " ";// Shipping.PostCode;
            request.DeliveryCountry = Shipping.Country;
            //Optional
            request.CustomerEmail = Billing.Email;
            request.ApplyAvsCv2 = 2;
            request.Apply3dSecure = 0;//3
            request.ReferrerId = "";
            request.AccountType = "E";
            request.Profile = "NORMAL";
            request.BasketXml = "<basket><item><description>AirFare Ticket</description><quantity>1</quantity><unitNetAmount>" + PayAmount + "</unitNetAmount><unitTaxAmount>0</unitTaxAmount><unitGrossAmount>" + PayAmount + "</unitGrossAmount><totalGrossAmount>" + PayAmount + "</totalGrossAmount></item></basket>";

            //if ((request.Amount * cardCharge) > 56)
            //{
            //    request.SurchargeXml = "<surcharges><surcharge><paymentType>VISA</paymentType><fixed>56</fixed></surcharge><surcharge><paymentType>MC</paymentType><fixed>56</fixed></surcharge><surcharge><paymentType>AMEX</paymentType><fixed>56</fixed></surcharge></surcharges>";
            //}
            //else { 
            request.SurchargeXml = "<surcharges><surcharge><paymentType>VISA</paymentType><percentage>0</percentage></surcharge><surcharge><paymentType>MC</paymentType><percentage>0</percentage></surcharge><surcharge><paymentType>AMEX</paymentType><percentage>0</percentage></surcharge></surcharges>";
            //}

            request.NotificationUrl = NotificationUrl;
            request.CreateToken = 0;// (cart.Card.SaveTokenForFutureUse == true ? 1 : 0);
        }
        public void SetDirectPaymentRequestData(IDirectPayment request, CardInformationFNPL robj)
        {
            //if (Billing.FirstNames == "PRABHUTEST" && Billing.Surname == "DIAL")
            //{
            //    PayConnectingServer = "TEST";
            //}

            decimal cardCharge = Convert.ToDecimal(0.025);
            request.VpsProtocol = (ProtocolVersion)Enum.Parse(typeof(ProtocolVersion), "V_" + payProtocall.Replace(".", ""));
            request.TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), TransactionType);
            request.Vendor = VendorName;
            VendorTxCode = GetNewVendorTxCode();
            request.VendorTxCode = VendorTxCode;
            request.Amount = PayAmount;
            request.Currency = PayCurrency;
            request.Description = "Booking from GetMeRooms.co.uk";
            request.BillingSurname = robj.card.name.Split(' ')[robj.card.name.Split(' ').Length - 1];
            request.BillingFirstnames = robj.card.name.Split(' ')[0];
            request.BillingAddress1 = robj.card.billingAddress.line1 + " " + robj.card.billingAddress.line2;
            request.BillingCity = robj.card.billingAddress.city;
            request.BillingPostCode = robj.card.billingAddress.postcode;
            request.BillingCountry = "GB";
            request.DeliverySurname = request.BillingSurname;
            request.DeliveryFirstnames = request.BillingFirstnames;
            request.DeliveryAddress1 = robj.card.billingAddress.line1 + " " + robj.card.billingAddress.line2;
            request.DeliveryCity = robj.card.billingAddress.city;
            request.DeliveryPostCode = robj.card.billingAddress.postcode;
            request.DeliveryCountry = "GB";
            request.CustomerEmail = "test@gmail.com";
            //request.BillingAddress1 = robj.card.billingAddress.line1;
            //request.BillingAddress2 = robj.card.billingAddress.line2;
            //request.BillingPostCode = robj.card.billingAddress.postcode;
            //request.BillingCountry = robj.card.billingAddress.country;

            request.ApplyAvsCv2 = 2;
            request.Apply3dSecure = 0;//3

            request.CardType = (CardType)Enum.Parse(typeof(CardType), robj.card.scheme);
            request.CardHolder = robj.card.name;

            request.CardNumber = robj.card.pan;
            //request.StartDate = string.Empty;
            //request.ExpiryDate = robj.card.expiry.month.ToString() + robj.card.expiry.year.ToString();
            request.ExpiryDate = robj.card.expiry.month.ToString("D2") + robj.card.expiry.year.ToString("D2");
            request.Cv2 = Convert.ToString(robj.card.cvv);




        }

        public string GetNewVendorTxCode()
        {
            Random random = new Random();
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            // 18 char max -13 chars - 6 chars
            return string.Format("{0}-{1}-{2}",
                VendorName.Substring(0, Math.Min(18, VendorName.Length)),
                (long)ts.TotalMilliseconds, random.Next(100000, 999999));
        }
    }


    //public class Funded
    //{
    //    public string amount { get; set; }
    //    public string currency { get; set; }
    //}

    //public class Details
    //{
    //    public string scheme { get; set; }
    //    public string name { get; set; }
    //    public string number { get; set; }
    //    public string expiry { get; set; }
    //    public string cvv { get; set; }
    //}

    //public class Address
    //{
    //    public string line1 { get; set; }
    //    public string line2 { get; set; }
    //    public string line3 { get; set; }
    //    public string city { get; set; }
    //    public string postalcode { get; set; }
    //}

    ////public class Card
    ////{
    ////    public Funded funded { get; set; }
    ////    public Details details { get; set; }
    ////    public Address address { get; set; }
    ////}

    //public class Reference
    //{
    //    public string virtual_card { get; set; }
    //    public string payment_card { get; set; }
    //    public string transaction { get; set; }
    //    public string request { get; set; }
    //}

    //public class RootObject
    //{
    //    public bool error { get; set; }
    //    public Card card { get; set; }
    //    public Reference reference { get; set; }
    //}



    // CardInformationFNPL myDeserializedClass = JsonConvert.DeserializeObject<CardInformationFNPL>(myJsonResponse); 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    // test card schema
    //public class Funded
    //{
    //    public string amount { get; set; }
    //    public string currency { get; set; }
    //}

    //public class Expiry
    //{
    //    public int year { get; set; }
    //    public int month { get; set; }
    //}

    //public class Details
    //{
    //    public string scheme { get; set; }
    //    public string name { get; set; }
    //    public string number { get; set; }
    //    public Expiry expiry { get; set; }
    //    public int cvv { get; set; }
    //}

    //public class Address
    //{
    //    public string line1 { get; set; }
    //    public string line2 { get; set; }
    //    public string line3 { get; set; }
    //    public string city { get; set; }
    //    public string postalcode { get; set; }
    //}

    //public class Card
    //{
    //    public Funded funded { get; set; }
    //    public Details details { get; set; }
    //    public Address address { get; set; }
    //}

    //public class Reference
    //{
    //    public string request { get; set; }
    //}

    //public class Currency
    //{
    //    public string name { get; set; }
    //    public string code { get; set; }
    //    public string iso { get; set; }
    //}

    //public class Summary
    //{
    //    public Currency currency { get; set; }
    //}

    //public class CardInformationFNPL
    //{
    //    public bool error { get; set; }
    //    public Card card { get; set; }
    //    public Reference reference { get; set; }
    //    public string merchantReference { get; set; }
    //    public string checkoutToken { get; set; }
    //    public string accountToken { get; set; }
    //    public string applicationToken { get; set; }
    //    public Summary summary { get; set; }
    //}
    //test end

    //live schema
    public class Currency
    {
        public string name { get; set; }
        public string code { get; set; }
        public string iso { get; set; }
    }

    public class Summary
    {
        public Currency currency { get; set; }
        public int amountRequested { get; set; }
        public int amountIssued { get; set; }
        public int amountAuthorised { get; set; }
    }

    public class Expiry
    {
        public int month { get; set; }
        public int year { get; set; }
    }

    public class BillingAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }

    public class Card
    {
        public string scheme { get; set; }
        public string name { get; set; }
        public string pan { get; set; }
        public Expiry expiry { get; set; }
        public string cvv { get; set; }
        public BillingAddress billingAddress { get; set; }
        public string registrationTime { get; set; }
    }

    public class CardInformationFNPL
    {
        public string merchantReference { get; set; }
        public string checkoutToken { get; set; }
        public string accountToken { get; set; }
        public string applicationToken { get; set; }
        public Summary summary { get; set; }
        public Card card { get; set; }
    }
    //live end


}
