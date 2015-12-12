
using System;

namespace Web.Exceptions
{
    [Serializable()]
    public class AddException : System.ApplicationException
    {
        public AddException()
            : base()
        {
        }

        public AddException(string strMessage)
            : base(strMessage)
        {
        }
    }
}
