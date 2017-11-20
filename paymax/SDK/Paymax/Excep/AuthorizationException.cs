using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Excep
{
    public class AuthorizationException : PaymaxException
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string message)
            : base(message)
        {
        }
    }
}
