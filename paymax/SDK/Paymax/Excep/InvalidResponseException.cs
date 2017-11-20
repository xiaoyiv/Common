using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Excep
{
    public class InvalidResponseException : PaymaxException
    {
        public InvalidResponseException()
        {
        }

        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}
