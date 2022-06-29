using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Exceptions
{
    public class NullPointException : Exception
    {
        public NullPointException()
        {
        }

        public NullPointException(string message) : base(message)
        {
        }

        public NullPointException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
