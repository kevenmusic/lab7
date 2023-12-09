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

    public class IndividualCarException : Exception
    {
        public IndividualCarException()
        {

        }

        public IndividualCarException(string message) : base(message)
        {

        }
    }

    public class LegalCarException : Exception
    {
        public LegalCarException()
        {

        }

        public LegalCarException(string message) : base(message)
        {

        }
    }
}
