
using System;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class EditException : System.ApplicationException
    {
        public EditException()
            : base()
        {
        }

        public EditException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public EditException(string strMessage)
            : base(strMessage)
        {
        }

        public EditException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}