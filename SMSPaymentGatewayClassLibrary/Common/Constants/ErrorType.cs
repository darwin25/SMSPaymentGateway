
using System;

namespace Web.Constants
{
    [Serializable()]
    public class ErrorType
    {
        public ErrorType()
        {
        }

        public const Int16 ADD = 1;
        public const Int16 EDIT = 2;
        public const Int16 DELETE = 3;
        public const Int16 SEARCH = 4;
        public const Int16 ACTION = 5;
        public const Int16 WEBPAGE = 6;
        public const Int16 PARSING = 7;
    }
}