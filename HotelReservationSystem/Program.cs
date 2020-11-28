using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        public static CustomerType customerType;
        public static DateTime startDate;
        public static DateTime endDate;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotels in Miami!");                                        //Welcome to Hotel Reservation System

            inputFromUserserInput();                                                                                //Input Date Range and Customer Type from User
            
            HotelReservation hotelReservation = new HotelReservation();

            AddSampleHotels(hotelReservation);                                                        //Add Hotel Name to HotelList

            //Find the cheapest hotel in the date Range
            var cheapestHotels = hotelReservation.FindCheapestHotels(startDate, endDate, customerType);
            var cost = hotelReservation.CalculateTotalCost(cheapestHotels[0], startDate, endDate, customerType);

            //Print the name and cost
            Console.WriteLine("Hotel: {0}, Total Cost : {1}", cheapestHotels[0].name, cost) ;                       //Print the Name of first Element if same

            //Best Rated Hotel in the date Range
            var bestRatedHotel = hotelReservation.FindBestRatedHotel(startDate, endDate);
            Console.WriteLine("Hotel: {0} Rating: {1}", bestRatedHotel[0].name,bestRatedHotel[0].rating);

            //Best and cheapest hotels

            var bestandcheapesthotel = hotelReservation.FindCheapestBestRatedHotel(endDate, endDate, customerType);
            var totalcost = hotelReservation.CalculateTotalCost(cheapestHotels[0], startDate, endDate, customerType);
            Console.WriteLine("Hotel: {0} Rating {1} Cost ",bestandcheapesthotel[0].name,bestandcheapesthotel[0].rating,cost);
        }

        public static void inputFromUserserInput()
        {
            Console.Write("Enter the type of Customer : ");                                         //Enter the Type of Customer
            var type = Console.ReadLine().ToLower();
            
            if (!HotelReservation.ValidateCustomerType(type))
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Customer Type is invalid");                //Check Validation to return Exception

            customerType = HotelReservation.GetCustomerType(type);                                    //Set the type of Customer
            
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();                                                          //Insert Date in dd/mm/yyyy form with , seoartator
            string[] dates = input.Split(',');
            
            startDate = Convert.ToDateTime(dates[0]);                                               
            endDate = Convert.ToDateTime(dates[1]);
        }

        //List to Add values to the Hotel
        public static void AddSampleHotels(HotelReservation hotelReservation)
        {
            hotelReservation.AddHotel(new Hotel { name = "Lakewood", weekdayRatesRegular = 110, weekendRatesRegular = 90, weekdayRatesLoyalty = 80, weekendRatesLoyalty = 80, rating = 3 });
            hotelReservation.AddHotel(new Hotel { name = "Bridgewood", weekdayRatesRegular = 160, weekendRatesRegular = 60, weekdayRatesLoyalty = 110, weekendRatesLoyalty = 50, rating = 4 });
            hotelReservation.AddHotel(new Hotel { name = "Ridgewood", weekdayRatesRegular = 220, weekendRatesRegular = 150, weekdayRatesLoyalty = 100, weekendRatesLoyalty = 40, rating = 5 });

        }
    }
}
