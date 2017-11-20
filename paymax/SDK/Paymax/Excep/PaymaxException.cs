using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Excep
{
    public abstract class PaymaxException : System.Exception
    {
        public PaymaxException()
        {
        }

        public PaymaxException(string message) : base(message)
        {
        }
    }
}
