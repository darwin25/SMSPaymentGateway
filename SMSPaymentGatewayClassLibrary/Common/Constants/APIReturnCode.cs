
using System;
namespace Web.Constants
{
    [Serializable()]
    public class APIReturnCode
    {


        public const string SUCCESSFUL_VALIDATION = "0";
        public const string RECEIVER_EMAIL_ADDRESS_INVALID = "1";
        public const string SENDER_EMAIL_ADDRESS_INVALID = "2";
        public const string SENDER_FIRSTNAME_BLANK = "3";
        public const string SENDER_LASTNAME_BLANK = "4";
        public const string SENDER_ADDRESS_BLANK = "5";
        public const string SENDER_PROVINCE_BLANK = "6";
        public const string SENDER_TOWN_BLANK = "7";
        public const string INVALID_MOBILE_NUMBER_FORMAT = "8";
        public const string ORDER_AMOUNT_NOT_NUMERIC = "9";
        public const string ORDER_AMOUNT_INVALID = "10";
        public const string ORDER_DESCRIPTION_BLANK = "11";
        public const string RECEIVER_EMAIL_ADDRESS_NOT_MERCHANT_ACCOUNT = "12";
        public const string RECEIVER_EMAIL_ADDRESS_DOES_NOT_EXIST = "13";
        public const string INVALID_TOKEN_ID = "14";
        public const string INVALID_SIGNATURE = "15";
    }
}
