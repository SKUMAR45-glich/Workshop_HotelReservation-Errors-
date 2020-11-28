using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelReservationSystem
{
    public enum CustomerType { Regular, Reward };
    public class HotelReservation
    {
        public Dictionary<string, Hotel> hotels;

        //Default Constructor
        public HotelReservation()
        {
            hotels = new Dictionary<string, Hotel>();
        }
        
        //Add Hotel Details to the Dictionary with Hotel name as key
        public void AddHotel(Hotel hotel)
        {
            if (hotels.ContainsKey(hotel.name))
            {
                Console.WriteLine("Plaese Enter other HotelName");
                return;
            }
            hotels.Add(hotel.name, hotel);
        }

        //Get Customer Type
        public static CustomerType GetCustomerType(string customerType)
        {
            if (customerType != "regular" && customerType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            
            return customerType == "regular" ? CustomerType.Regular : CustomerType.Reward;
        }

        //Validate Customer Type
        public static bool ValidateCustomerType(string customerType)
        {
            var customerTypeRegex = "^([Rr]eward|[Rr]egular)$";                       //Regex Validation
            var regex = new Regex(customerTypeRegex);
            return regex.IsMatch(customerType);
        }


        //List of Hotels with Cheapest Rate
        public List<Hotel> FindCheapestHotels(DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            if (startDate > endDate)
            {
                throw new HotelReservationException(ExceptionType.INVALID_DATES, "Dates Entered are Invalid");             //Exception
            }

            var cost = Int32.MaxValue;                                                       //MaxValue
            var cheapestHotels = new List<Hotel>();                                            
            
            foreach (var hotel in hotels)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateTotalCost(hotel.Value, startDate, endDate, customerType));                 //Function to Compare

            }
            
            foreach (var hotel in hotels)
            {
                if (CalculateTotalCost(hotel.Value, startDate, endDate, customerType) == cost)                                 //If Minimum add to the list
                    cheapestHotels.Add(hotel.Value);
            }

            return cheapestHotels;
        }

        //Total Cost
        public int CalculateTotalCost(Hotel hotel, DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            var cost = 0;
            var weekdayRate = customerType == CustomerType.Regular ? hotel.weekdayRatesRegular : hotel.weekdayRatesLoyalty;
            var weekendRate = customerType == CustomerType.Regular ? hotel.weekendRatesRegular : hotel.weekendRatesLoyalty;
            
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))                            //forloop for date
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)                       //If Weekend
                    cost += weekendRate;
                else
                    cost += weekdayRate;                                                            //Normal day
            }

            return cost;                                                                          //Total cost
        }

        //Best Rated Hote;
        public List<Hotel> FindBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            var bestRatedHotels = new List<Hotel>();
            var maxRating = 0;                                                                    //Can be Int32.Min also
            
            foreach (var hotel in hotels)
                maxRating = Math.Max(maxRating, hotel.Value.rating);                                  //Loop to get Maximum value
            
            foreach (var hotel in hotels)
                if (hotel.Value.rating == maxRating)
                    bestRatedHotels.Add(hotel.Value);
            
            return bestRatedHotels;

        }

        //Find CheapestBestRated Hotel

        public List<Hotel> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            var cheapandbestHotels = FindCheapestHotels(startDate, endDate, customerType);                           //take the cheapest hotel 
            
            var cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            
            foreach (var hotel in cheapandbestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);                                                          //COmpare to get the best rated hotel
            
            foreach (var hotel in cheapandbestHotels)
                if (hotel.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel);                                                            //Add to the list
            
            return cheapestBestRatedHotels;

        }

    }
}