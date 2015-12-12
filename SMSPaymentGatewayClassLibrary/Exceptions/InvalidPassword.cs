
using System;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class InvalidPassword : System.ApplicationException
    {
        public InvalidPassword()
            : base()
        {
        }

        public InvalidPassword(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public InvalidPassword(string strMessage)
            : base(strMessage)
        {
        }

        public InvalidPassword(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}

