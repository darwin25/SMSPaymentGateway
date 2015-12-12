
using System;
using System.Runtime.Serialization;


namespace Web.Exceptions
{
    [Serializable()]
    public class PageException : System.ApplicationException
    {
        public PageException()
            : base()
        {
        }

        public PageException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public PageException(string strMessage)
            : base(strMessage)
        {
        }

        public PageException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}
