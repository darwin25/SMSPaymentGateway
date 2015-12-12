
using System;
using System.Runtime.Serialization;
namespace Web.Exceptions
{
    [Serializable()]
    public class RevokeUserException : System.ApplicationException
    {
        public RevokeUserException()
            : base()
        {
        }

        public RevokeUserException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public RevokeUserException(string strMessage)
            : base(strMessage)
        {
        }

        public RevokeUserException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}

