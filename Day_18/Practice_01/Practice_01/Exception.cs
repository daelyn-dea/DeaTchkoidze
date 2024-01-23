using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    internal class AmountExceptionLogic : Exception
    {
        public AmountExceptionLogic(string message) : base(string.Format("You can't transfer amoutn.  {0}", message))
        { }
    }

    internal class IBANValidException : Exception
    {
        public IBANValidException(string message) : base(string.Format("You choosed inccorect IBAN.  {0}", message))
        { }
    }
}
