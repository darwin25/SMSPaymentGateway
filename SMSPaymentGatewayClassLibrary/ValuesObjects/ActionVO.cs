using System;

namespace Web.ValueObjects
{
    [Serializable()]
    public class ActionVO
    {
        private string strPath;
        private string strActionClass;
        private string strCommandName;
        private string strNextPage;
        private string strError;
        private string strForward;
        private string strForwardPath;

        private string strForwardRoleName;
        public ActionVO()
        {
        }

        public string path
        {
            get { return strPath; }
            set { strPath = value; }
        }

        public string actionClass
        {
            get { return strActionClass; }
            set { strActionClass = value; }
        }

        public string commandName
        {
            get { return strCommandName; }
            set { strCommandName = value; }
        }

        public string nextPage
        {
            get { return strNextPage; }
            set { strNextPage = value; }
        }

        public string errorPage
        {
            get { return strError; }
            set { strError = value; }
        }

        public string forward
        {
            get { return strForward; }
            set { strForward = value; }
        }

        public string forwardPath
        {
            get { return strForwardPath; }
            set { strForwardPath = value; }
        }

        public string fowardRoleName
        {
            get { return strForwardRoleName; }
            set { strForwardRoleName = value; }
        }
    }
}
