
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Web;
using System.Runtime.Serialization;

namespace Web.Exceptions
{
    [Serializable()]
    public class SearchException : System.ApplicationException
    {
        public SearchException()
            : base()
        {
        }

        public SearchException(string strMessage, System.Exception excException)
            : base(strMessage, excException)
        {
        }

        public SearchException(string strMessage)
            : base(strMessage)
        {
        }

        public SearchException(SerializationInfo serialization, StreamingContext stream)
            : base(serialization, stream)
        {
        }
    }
}
