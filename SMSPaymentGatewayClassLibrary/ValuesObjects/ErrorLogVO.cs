
using System;

namespace Web.ValueObjects
{

    [Serializable()]
    public class ErrorLogVO
    {

        private string oUserID;
        private System.DateTime oDateLog;
        private DateTime oTimeLog;
        private string oIncidence;
        private string oIncidenceDetail;
        private string oMachineID;
        private string oIPAddress;

        private string oExternalIPAddress;
        public string UserID
        {
            get { return oUserID; }
            set { oUserID = value; }
        }

        public System.DateTime DateLog
        {
            get { return oDateLog; }
            set { oDateLog = value; }
        }

        public DateTime TimeLog
        {
            get { return oTimeLog; }
            set { oTimeLog = value; }
        }

        public string Incidence
        {
            get { return oIncidence; }
            set { oIncidence = value; }
        }

        public string IncidenceDetail
        {
            get { return oIncidenceDetail; }
            set { oIncidenceDetail = value; }
        }


        public string MachineID
        {
            get { return oMachineID; }
            set { oMachineID = value; }
        }

        public string IPAddress
        {
            get { return oIPAddress; }
            set { oIPAddress = value; }
        }

        public string ExternalIPAddress
        {
            get { return oExternalIPAddress; }
            set { oExternalIPAddress = value; }
        }

    }

}
