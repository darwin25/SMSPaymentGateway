
using System;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class DuplicateKeyException : System.ApplicationException
    {
        public DuplicateKeyException()
            : base()
        {
        }

        public DuplicateKeyException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public DuplicateKeyException(string strMessage)
            : base(strMessage)
        {
        }

        public DuplicateKeyException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}
