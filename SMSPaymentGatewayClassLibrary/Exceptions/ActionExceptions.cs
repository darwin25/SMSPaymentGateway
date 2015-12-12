
using System;

namespace Web.Exceptions
{
    [Serializable()]
    public class ActionExceptions : System.ApplicationException
    {
        public ActionExceptions()
            : base()
        {
        }

        public ActionExceptions(string strMessage)
            : base(strMessage)
        {
        }

    }
}

