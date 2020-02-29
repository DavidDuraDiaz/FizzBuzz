using System;

namespace FizzBuzzCore.Exceptions
{
    public class InvalidRangeException : Exception
    {
        public InvalidRangeException() : base() { }
        public InvalidRangeException(string message) : base(message) { }
    }
}
