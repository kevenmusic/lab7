using System;

namespace ClassLibrary7
{
    public class CarException : Exception
    {
        public CarException()
        {
        }

        public CarException(string message) : base(message)
        {
        }
    }
}
