using Data.GetMeRoom;
using Data.GetMeRoom.Models.Search;
using System;
using System.Linq;

namespace Business.GetMeRoom
{
    public static class CurrencyConveraion
    {
        static SearchRS_V1 searchRS_V1 = new SearchRS_V1();
        public static double CONVERTION_RATE = GlobalConstant.ConfigVariables.CONVERTION_RATE;
        public static string CURRENCY = GlobalConstant.ConfigVariables.CURRENCY;
        public static SearchRS_V1 ConvertCurrencyListing(SearchRS_V1 searchRS)
        {
            if (CURRENCY == "INR")
            {
                if (searchRS?.Hotels?.Hotel == null)
                {
                    return new SearchRS_V1();
                }

                foreach (Hotel _hotel in searchRS?.Hotels?.Hotel)
                {
                    foreach (Rate _rate in _hotel?.Rates)
                    {
                        foreach (RoomSerchRS room in _rate.Room)
                        {
                            room.NetCurrency = CURRENCY;
                            room.NetPrice = Math.Round((room.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        }
                    }

                    _hotel.NetCurrency = CURRENCY;
                    _hotel.NetPrice = Math.Round((_hotel.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                    _hotel.GrossPrice = Math.Round((_hotel.GrossPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                    _hotel.GrossCurrency = CURRENCY;
                }
            }
            return searchRS;
        }

        public static Data.GetMeRoom.Models.Detail.GetRoomsRS_V1 ConvertCurrencyDetail(Data.GetMeRoom.Models.Detail.GetRoomsRS_V1 getRoomRS)
        {
            if (CURRENCY == "INR")
            {
                if (getRoomRS?.Hotels?.Hotel == null)
                {
                    return new Data.GetMeRoom.Models.Detail.GetRoomsRS_V1();
                }

                foreach (Data.GetMeRoom.Models.PreBook.Rate _rates in getRoomRS?.Hotels.Hotel.Rates)
                {

                    foreach (Data.GetMeRoom.Models.PreBook.Room room in _rates.Room)
                    {
                        room.NetCurrency = CURRENCY;
                        room.NetPrice = Math.Round((room.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        room.GrossCurrency = CURRENCY;
                        room.GrossPrice = Math.Round((room.GrossPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        foreach (Data.GetMeRoom.Models.PreBook.DailyRate _dailyrate in room.DailyRates)
                        {
                            _dailyrate.NetPrice = Math.Round((_dailyrate.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                            _dailyrate.GrossPrice = Math.Round((_dailyrate.GrossPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        }
                        if (room?.Policies?.Policy != null)
                        {
                            foreach (Data.GetMeRoom.Models.PreBook.Policy _policy in room?.Policies?.Policy)
                            {
                                _policy.EstimatedValue = Math.Round((_policy.EstimatedValue * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                                _policy.Value = Convert.ToDouble(_policy.EstimatedValue);
                            }
                        }
                    }
                }
                getRoomRS.Hotels.Hotel.MinPrice = getRoomRS.Hotels.Hotel.Rates.FirstOrDefault().Room.OrderBy(x => x.GrossPrice).FirstOrDefault().GrossPrice;

            }
            return getRoomRS;
        }

        public static Data.GetMeRoom.Models.PreBook.PreBookRS_V1 ConvertCurrencyPreBook(Data.GetMeRoom.Models.PreBook.PreBookRS_V1 preBookRS_V1)
        {
            if (CURRENCY == "INR")
            {
                if (preBookRS_V1?.Hotel?.Rate == null)
                {
                    return new Data.GetMeRoom.Models.PreBook.PreBookRS_V1();
                }

                foreach (Data.GetMeRoom.Models.PreBook.Room _rooms in preBookRS_V1?.Hotel?.Rate?.Room)
                {
                    _rooms.NetCurrency = CURRENCY;
                    _rooms.NetPrice = Math.Round((_rooms.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                    _rooms.GrossPrice = Math.Round((_rooms.GrossPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                    _rooms.GrossCurrency = CURRENCY;
                    foreach (Data.GetMeRoom.Models.PreBook.DailyRate _dailyrate in _rooms.DailyRates)
                    {
                        _dailyrate.NetPrice = Math.Round((_dailyrate.NetPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        _dailyrate.GrossPrice = Math.Round((_dailyrate.GrossPrice * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                    }
                    if (_rooms?.Policies?.Policy != null)
                    {
                        foreach (Data.GetMeRoom.Models.PreBook.Policy _policy in _rooms?.Policies?.Policy)
                        {
                            _policy.Value = Math.Round((_policy.Value * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                            _policy.EstimatedValue = Math.Round((_policy.EstimatedValue * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
                preBookRS_V1.Hotel.MinPrice = Convert.ToString(Math.Round((Convert.ToDouble(preBookRS_V1.Hotel.MinPrice) * CONVERTION_RATE), 2, MidpointRounding.AwayFromZero));
                preBookRS_V1.ResponseInfo.Currency = CURRENCY;
            }
            return preBookRS_V1;
        }
    }
}
