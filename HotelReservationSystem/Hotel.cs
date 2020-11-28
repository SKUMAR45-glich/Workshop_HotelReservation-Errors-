using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string name { get; set; }
        public int weekdayRatesRegular { get; set; }
        public int weekendRatesRegular { get; set; }
        public int weekdayRatesLoyalty { get; set; }
        public int weekendRatesLoyalty { get; set; }
        public int rating { get; set; }
    }
}


