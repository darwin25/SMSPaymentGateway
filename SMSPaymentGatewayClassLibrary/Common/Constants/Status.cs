
using System;
namespace Web.Constants
{

    [Serializable()]
    public class ActionResult
    {
        public const string ACTION_FAILED = "0";
        public const string ACTION_SUCCESSFUL = "1";
    }

    [Serializable()]
    public class RRNStatus
    {
        public const string UNASSIGNED = "0";
        public const string ASSIGNED = "1";
    }
    
    [Serializable()]
    public class PaymentAmount
    {
        public const string PAYMENTAMOUNT_EQUALS_ORDERAMOUNT = "1";
        public const string PAYMENTAMOUNT_GREATER_THAN_ORDERAMOUNT = "2";
        public const string PAYMENTAMOUNT_LESS_THAN_ORDERAMOUNT = "3";

        public const string PAYMENTAMOUNT_EQUALS_FUNDINGAMOUNT = "1";
        public const string PAYMENTAMOUNT_GREATER_THAN_FUNDINGAMOUNT = "2";
        public const string PAYMENTAMOUNT_LESS_THAN_FUNDINGAMOUNT = "3";
    }

    [Serializable()]
    public class TransactionStatus
    {
        public const string TRANSACTION_PENDING = "Pending";
        public const string TRANSACTION_PAID = "Paid";
        public const string TRANSACTION_RECEIVED = "Payment Received";
        public const string TRANSACTION_CANCELLED = "Cancelled";
        public const string TRANSACTION_EXPIRED = "Expired";
        public const string TRANSACTION_INTRANSIT = "In Transit";
        
        public const string TRANSACTION_PENDING_CODE = "PN";
        public const string TRANSACTION_PAID_CODE = "PD";
        public const string TRANSACTION_RECEIVED_CODE = "RC";
        public const string TRANSACTION_CANCELLED_CODE = "CN";
        public const string TRANSACTION_EXPIRED_CODE = "EX";
        public const string TRANSACTION_INTRANSIT_CODE = "IT";
    }



}
