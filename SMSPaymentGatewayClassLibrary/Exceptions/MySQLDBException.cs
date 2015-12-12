
using System;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class MySQLDBException : System.ApplicationException
    {
        public MySQLDBException()
            : base()
        {
        }

        public MySQLDBException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public MySQLDBException(string strMessage)
            : base(strMessage)
        {
        }

        public MySQLDBException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}
