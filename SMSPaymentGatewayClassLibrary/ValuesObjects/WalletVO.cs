
using System;


namespace Web.ValueObjects
{
    [Serializable()]
    public class WalletVO: CustomerVO
    { 
        private string oUniqueTransactionCode;
        private double oFundingAmount;
        private string oFundingCurrency;
        private string oFundingDescription;
        private string oFundingStatus;
        private string oRemittanceReferenceNumber;
        private string oRemittanceReferenceNumberStatus;

        public string UniqueTransactionCode
        {
            get { return oUniqueTransactionCode; }
            set { oUniqueTransactionCode = value; }
        }

        public double FundingAmount
        {
            get { return oFundingAmount; }
            set { oFundingAmount = value; }
        }

        public string FundingCurrency
        {
            get { return oFundingCurrency; }
            set { oFundingCurrency = value; }
        }

        public string FundingDescription
        {
            get { return oFundingDescription; }
            set { oFundingDescription = value; }
        }

        public string FundingStatus
        {
            get { return oFundingStatus; }
            set { oFundingStatus = value; }
        }

        public string RemittanceReferenceNumber
        {
            get { return oRemittanceReferenceNumber; }
            set { oRemittanceReferenceNumber = value; }
        }

        public string RemittanceReferenceNumberStatus
        {
            get { return oRemittanceReferenceNumberStatus; }
            set { oRemittanceReferenceNumberStatus = value; }
        }

    }
}
