
using System;

namespace Web.Constants
{
    [Serializable()]
    public class AppParameters
    {
        public AppParameters()
        {
        }


        public const string ACTION_ADD = "ADD";

        public const string ACTION_EDIT = "EDIT";

        public const string ACTION_SEARCH = "SEARCH";

        public const string ACTION_DELETE = "DELETE";

        public const string STATUS = "AUTHORIZED";

        public const string ACTION_HOST = "HOST";
    }
}
