﻿using System;
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
