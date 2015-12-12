
using System;

namespace Web.ValueObjects
{
    [Serializable()]
    public class OrdersVO : CustomerVO
    {

        private string oUniqueTransactionCode;
        private string oBuyerCustomerID;
        private string oSellerCustomerID;
        private double oOrderAmount;
        private string oOrderCurrency;
        private string oOrderDescription;
        private string oOrderSKU;
        private string oOrderStatus;
        private string oRemittanceReferenceNumber;
        private string oRemittanceReferenceNumberStatus;
        private string oDeliveryProvider;
        private string oTrackingNumber;
        //Private oDateValue1 As Date
        //Private oDateValue2 As Date
        //Private oDateValue3 As Date
        //Private oDateValue4 As Date

        public string UniqueTransactionCode
        {
            get { return oUniqueTransactionCode; }
            set { oUniqueTransactionCode = value; }
        }

        public string BuyerCustomerID
        {
            get { return oBuyerCustomerID; }
            set { oBuyerCustomerID = value; }
        }

        public string SellerCustomerID
        {
            get { return oSellerCustomerID; }
            set { oSellerCustomerID = value; }
        }

        public double OrderAmount
        {
            get { return oOrderAmount; }
            set { oOrderAmount = value; }
        }

        public string OrderCurrency
        {
            get { return oOrderCurrency; }
            set { oOrderCurrency = value; }
        }

        public string OrderDescription
        {
            get { return oOrderDescription; }
            set { oOrderDescription = value; }
        }

        public string OrderSKU
        {
            get { return oOrderSKU; }
            set { oOrderSKU = value; }
        }

        public string OrderStatus
        {
            get { return oOrderStatus; }
            set { oOrderStatus = value; }
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

        public string DeliveryProvider
        {
            get { return oDeliveryProvider; }
            set { oDeliveryProvider = value; }
        }

        public string TrackingNumber
        {
            get { return oTrackingNumber; }
            set { oTrackingNumber = value; }
        }
        //Public Property DateValue1() As Date
        //    Get
        //        Return oDateValue1
        //    End Get
        //    Set(ByVal value As Date)
        //        oDateValue1 = value
        //    End Set
        //End Property

        //Public Property DateValue2() As Date
        //    Get
        //        Return oDateValue2
        //    End Get
        //    Set(ByVal value As Date)
        //        oDateValue2 = value
        //    End Set
        //End Property

        //Public Property DateValue3() As Date
        //    Get
        //        Return oDateValue3
        //    End Get
        //    Set(ByVal value As Date)
        //        oDateValue3 = value
        //    End Set
        //End Property

        //Public Property DateValue4() As Date
        //    Get
        //        Return oDateValue4
        //    End Get
        //    Set(ByVal value As Date)
        //        oDateValue4 = value
        //    End Set
        //End Property

    }
}

