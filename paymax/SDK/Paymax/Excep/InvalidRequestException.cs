using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Excep
{
    public class InvalidRequestException : PaymaxException
    {
        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message)
            : base(message)
        {
        }
    }
}
