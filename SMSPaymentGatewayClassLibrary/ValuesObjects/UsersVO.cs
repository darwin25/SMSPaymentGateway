
using System;


namespace Web.ValueObjects
{
    [Serializable()]
    public class UsersVO : CustomerVO
    {

        private string oUserID;
        private string oUserName;
        private string oUserName2;
        private string oUserPassword;
        private string oUserPassword2;
        private string oForceChangePassword;
        private string oUserType;
        private string oIPAddress;
        private string oCreatedBy;
        private string oCertificate;

        private string oURL;



        public string IPAddress
        {
            get { return oIPAddress; }
            set { oIPAddress = value; }
        }

        public string UserID
        {
            get { return oUserID; }
            set { oUserID = value; }
        }

        public string UserName
        {
            get { return oUserName; }
            set { oUserName = value; }
        }

        public string UserName2
        {
            get { return oUserName2; }
            set { oUserName2 = value; }
        }

        public string UserPassword
        {
            get { return oUserPassword; }
            set { oUserPassword = value; }
        }

        public string UserPassword2
        {
            get { return oUserPassword2; }
            set { oUserPassword2 = value; }
        }

        public string ForceChangePassword
        {
            get { return oForceChangePassword; }
            set { oForceChangePassword = value; }
        }

        public string UserType
        {
            get { return oUserType; }
            set { oUserType = value; }
        }

        public string CreatedBy
        {
            get { return oCreatedBy; }
            set { oCreatedBy = value; }
        }

        public string Certificate
        {
            get { return oCertificate; }
            set { oCertificate = value; }
        }



        public string URL
        {
            get { return oURL; }
            set { oURL = value; }
        }

    }
}
