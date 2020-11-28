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

        public static CustomerType GetCustomerType(string customerType)
        {
            if (customerType != "regular" && customerType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            
            return customerType == "regular" ? CustomerType.Regular : CustomerType.Reward;
        }

        public static bool ValidateCustomerType(string customerType)
        {
            var customerTypeRegex = "^([Rr]eward|[Rr]egular)$";
            var regex = new Regex(customerTypeRegex);
            return regex.IsMatch(customerType);
        }
    }
}