using System;
using System.Runtime.Serialization;
namespace Web.ValueObjects
{

    [Serializable()]
    public class CustomerVO
    {

        private string oCustomerID;
        private string oFriendlyURLName;
        private string oFirstName;
        private string oLastName;
        private string oMiddleName;
        private string oBusinessName;
        private string oBusinessType;
        private string oWebsiteURL;
        private string oBusinessRegistrationNumber;
        private string oTaxIdentificationNumber;
        private string oEmailAddress1;
        private string oEmailAddress2;
        private string oEmailIsValidated;
        private string oMobileNumber;
        private string oTelephone;
        private string oCountry;
        private string oProvince;
        private string oTown;
        private string oZipCode;
        private string oAddress;
        private double oWalletBalance;
        private string oWithdrawMethodid;
        private string oPaymentOption;
        private string oBankAccount;
        private string oBankName;
        private string oRecepient;
        private System.DateTime oDateValue1;
        private System.DateTime oDateValue2;
        private System.DateTime oDateValue3;
        private System.DateTime oDateValue4;
        private string oTokenID;
        private string oAuthenticationCode;
        private string oAuthorizationStatus;

        public string CustomerID
        {
            get { return oCustomerID; }
            set { oCustomerID = value; }
        }

        public string FriendlyURLName
        {
            get { return oFriendlyURLName; }
            set { oFriendlyURLName = value; }
        }


        public string FirstName
        {
            get { return oFirstName; }
            set { oFirstName = value; }
        }

        public string MiddleName
        {
            get { return oMiddleName; }
            set { oMiddleName = value; }
        }

        public string LastName
        {
            get { return oLastName; }
            set { oLastName = value; }
        }

        public string BusinessName
        {
            get { return oBusinessName; }
            set { oBusinessName = value; }
        }

        public string BusinessType
        {
            get { return oBusinessType; }
            set { oBusinessType = value; }
        }

        public string WebsiteURL
        {
            get { return oWebsiteURL; }
            set { oWebsiteURL = value; }
        }

        public string BusinessRegistrationNumber
        {
            get { return oBusinessRegistrationNumber; }
            set { oBusinessRegistrationNumber = value; }
        }

        public string TaxIdentificationNumber
        {
            get { return oTaxIdentificationNumber; }
            set { oTaxIdentificationNumber = value; }
        }

        public string EmailAddress1
        {
            get { return oEmailAddress1; }
            set { oEmailAddress1 = value; }
        }

        public string EmailAddress2
        {
            get { return oEmailAddress2; }
            set { oEmailAddress2 = value; }
        }

        private string EmailIsValidated
        {
            get { return oEmailIsValidated; }
            set { oEmailIsValidated = value; }
        }

        public string MobileNumber
        {
            get { return oMobileNumber; }
            set { oMobileNumber = value; }
        }

        public string Telephone
        {
            get { return oTelephone; }
            set { oTelephone = value; }
        }

        public string Country
        {
            get { return oCountry; }
            set { oCountry = value; }
        }

        public string Province
        {
            get { return oProvince; }
            set { oProvince = value; }
        }

        public string Town
        {
            get { return oTown; }
            set { oTown = value; }
        }

        public string ZipCode
        {
            get { return oZipCode; }
            set { oZipCode = value; }
        }

        public string Address
        {
            get { return oAddress; }
            set { oAddress = value; }
        }

        public string WithdrawMethodid
        {
            get { return oWithdrawMethodid; }
            set { oWithdrawMethodid = value; }
        }

        public string PaymentOption
        {
            get { return oPaymentOption; }
            set { oPaymentOption = value; }
        }

        public string BankAccount
        {
            get { return oBankAccount; }
            set { oBankAccount = value; }
        }

        public string BankName
        {
            get { return oBankName; }
            set { oBankName = value; }
        }

        public string Recepient
        {
            get { return oRecepient; }
            set { oRecepient = value; }
        }

        public double WalletBalance
        {
            get { return oWalletBalance; }
            set { oWalletBalance = value; }
        }

        public System.DateTime DateValue1
        {
            get { return oDateValue1; }
            set { oDateValue1 = value; }
        }

        public System.DateTime DateValue2
        {
            get { return oDateValue2; }
            set { oDateValue2 = value; }
        }

        public System.DateTime DateValue3
        {
            get { return oDateValue3; }
            set { oDateValue3 = value; }
        }

        public System.DateTime DateValue4
        {
            get { return oDateValue4; }
            set { oDateValue4 = value; }
        }

        public string TokenID
        {
            get { return oTokenID; }
            set { oTokenID = value; }
        }

        public string AuthenticationCode
        {
            get { return oAuthenticationCode; }
            set { oAuthenticationCode = value; }
        }

        public string AuthorizationStatus
        {
            get { return oAuthorizationStatus; }
            set { oAuthorizationStatus = value; }
        }
    }

}
