
using System;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class UserException : System.ApplicationException
    {
        public UserException()
            : base()
        {
        }

        public UserException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public UserException(string strMessage)
            : base(strMessage)
        {
        }

        public UserException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}
