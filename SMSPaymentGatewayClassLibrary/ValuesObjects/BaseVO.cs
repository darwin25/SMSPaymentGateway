using System;


namespace Web.ValueObjects
{
    [Serializable()]
    public class BaseVO
    {
        private string strNextPage;
        private object strBorrowingNextPage;
        private string strSessionUID;
        private string strAction;

        private string strSearchItem;
        private string strParameter;
        private string strRoleID;

        private double dblBatchNo;
        public BaseVO()
        {
        }

        public string nextPage
        {
            get { return strNextPage; }
            set { strNextPage = value; }
        }

        public object borrowingNextPage
        {
            get { return strBorrowingNextPage; }
            set { strBorrowingNextPage = value; }
        }

        public string SessionUID
        {
            get { return this.strSessionUID; }
            set { this.strSessionUID = value; }
        }

        public string Action
        {
            get { return strAction; }
            set { strAction = value; }
        }

        public string SearchItem
        {
            get { return strSearchItem; }
            set { strSearchItem = value; }
        }

        public string Parameter
        {
            get { return strParameter; }
            set { strParameter = value; }
        }

        public string RoleName
        {
            get { return strRoleID; }
            set { strRoleID = value; }
        }

        public double BatchNo
        {
            get { return dblBatchNo; }
            set { dblBatchNo = value; }
        }
    }
}
