using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class InvalidCarException : Exception
    {
        public InvalidCarException(string message) : base(message)
        {

        }
    }
}
