using System;

namespace FizzBuzzCore.Exceptions
{
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException() : base() { }
        public InvalidKeyException(string message) : base(message) { }
    }
}
