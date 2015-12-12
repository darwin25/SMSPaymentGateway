using System;
using System.Data;
using Web.DAO;
using Web.Constants;
using Web.Helper;
using DBDataProvider;

namespace Web.Actions
{
    [Serializable()]
    public class GetOrderAction
    {

        public OrdersDAO dao = new OrdersDAO();
        #region "ActionObjectInterface Members"

        public GetOrderAction()
        {
        }


        public object CreateOrder(object obj)
        {
            try
            {
                return dao.CreateOrder(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object CreateOrder2(object obj)
        {
            try
            {
                return dao.CreateOrder2(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object UpdateOrder(object obj)
        {
            try
            {
                return dao.UpdateOrder(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object GetOrderStatus(object obj)
        {
            try
            {
                return dao.GetOrderStatus(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetOrderDetails(object obj)
        {
            try
            {
                return dao.GetOrderDetails(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetOrderDetails2(object obj)
        {
            try
            {
                return dao.GetOrderDetails2(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }


        public object GetRemittanceReferenceNumberStatus(object obj)
        {
            try
            {
                return dao.GetRemittanceReferenceNumberStatus(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object VerifyPaymentAndOrderAmount(object obj)
        {
            try
            {
                return dao.VerifyPaymentAndOrderAmount(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object AssignPaymentToOrder(object obj)
        {
            try
            {
                return dao.AssignPaymentToOrder(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }
            
            return null;
        }

        public DataSet GetOrders(string selleremailaddress, string orderstatus, DateTime fromdate, DateTime todate)
        {
            try
            {
                return dao.GetOrders(selleremailaddress, orderstatus, fromdate, todate);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetBuyerOrders(string buyereremailaddress, DateTime fromdate, DateTime todate)
        {
            try
            {
                return dao.GetBuyerOrders(buyereremailaddress, fromdate, todate);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }


        public DataSet GetMerchantDashboard(string selleremailaddress, DateTime fromdate, DateTime todate)
        {
            try
            {
                return dao.GetMerchantDashboard(selleremailaddress, fromdate, todate);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetBuyerDashboard(string buyeremailaddress, DateTime fromdate, DateTime todate)
        {
            try
            {
                return dao.GetBuyerDashboard(buyeremailaddress, fromdate, todate);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object GetPayments(string customeremailaddress, string paymentmode, System.DateTime date1, System.DateTime date2)
        {
            try
            {
                return dao.GetPayments(customeremailaddress, paymentmode, date1, date2);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetDeliveryProviders()
        {
            try
            {
                return dao.GetDeliveryProviders();
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        #endregion

    }
}
