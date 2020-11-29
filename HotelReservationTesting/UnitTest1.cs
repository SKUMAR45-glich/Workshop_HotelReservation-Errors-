using HotelReservationSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HotelReservationSystemTests
{
    [TestFixture]
    class HotelReservationTest
    {
        private HotelReservation _hotelReservation;


        //SetUp Hotel List
        [SetUp]
        public void SetUP()
        {
            _hotelReservation = new HotelReservation();
            _hotelReservation.AddHotel(new Hotel { name = "Lakewood", weekdayRatesRegular = 110, weekendRatesRegular = 90, weekdayRatesLoyalty = 80, weekendRatesLoyalty = 80, rating = 3 });
            _hotelReservation.AddHotel(new Hotel { name = "Bridgewood", weekdayRatesRegular = 160, weekendRatesRegular = 60, weekdayRatesLoyalty = 110, weekendRatesLoyalty = 50, rating = 4 });
            _hotelReservation.AddHotel(new Hotel { name = "Ridgewood", weekdayRatesRegular = 220, weekendRatesRegular = 150, weekdayRatesLoyalty = 100, weekendRatesLoyalty = 40, rating = 5 });
        }

        //Countthe Total Contact
        [Test]
        public void Countthetotalcontactafteraddition()
        {
            var hotel = new Hotel { name = "MyHotel", weekdayRatesRegular = 10, weekendRatesRegular = 20 };

            var prevCount = _hotelReservation.hotels.Count;
            _hotelReservation.AddHotel(hotel);

            Assert.That(_hotelReservation.hotels.Count, Is.EqualTo(prevCount + 1));
            Assert.That(_hotelReservation.hotels.ContainsKey(hotel.name), Is.True);

        }

        //Find the Cheapest 
        [Test]
        public void FindCheapestHotelsIntheDateRange()
        {
            var startDate = Convert.ToDateTime("10Sep2020");
            var endDate = Convert.ToDateTime("11Sep2020");

            var expected = _hotelReservation.hotels["Lakewood"];
            var result = _hotelReservation.FindCheapestHotels(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

        //Findthe Best Rated
        
        [Test]
        public void FindBestRatedHotelsintheDateRange()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            var expected = _hotelReservation.hotels["Ridgewood"];
            var result = _hotelReservation.FindBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

        //Find the Cheapest Best rated

        [Test]
        public void FindCheapestBestRatedHotelsIntheDateRange()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            var expected = _hotelReservation.hotels["Bridgewood"];
            var result = _hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }


        //Find the cheapest Best Rated for Loyal Customer

        [Test]
        public void FindCheapestBestRatedHotelsForLoyalCustomerinDateRange()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");

            var expected = _hotelReservation.hotels["Ridgewood"];
            var result = _hotelReservation.FindCheapestBestRatedHotel(startDate, endDate, CustomerType.Reward);

            Assert.That(result, Does.Contain(expected));
        }

    }
}