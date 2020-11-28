
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public enum ExceptionType { INVALID_CUSTOMER_TYPE, INVALID_DATES };

    public class HotelReservationException : Exception
    {
        public ExceptionType exceptionType;
        public HotelReservationException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
