using System;
using System.Data;
using Web.DAO;
using Web.Constants;
using Web.Helper;
using DBDataProvider;

namespace Web.Actions
{
    [Serializable()]
    public class GetWalletAction
    {

        public WalletDAO dao = new WalletDAO();
        #region "ActionObjectInterface Members"

        public GetWalletAction()
        {
        }


        public object AddFundsToWallet(object obj)
        {
            try
            {
                return dao.AddFundsToWallet(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public DataSet GetFundingDetails(object obj)
        {
            try
            {
                return dao.GetFundingDetails(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }
            return null;
        }

        public object AssignPaymentToFunding(object obj)
        {
            try
            {
                return dao.AssignPaymentToFunding(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object VerifyPaymentAndFundingAmount(object obj)
        {
            try
            {
                return dao.VerifyPaymentAndFundingAmount(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetWithdrawMethods(string emailaddress)
        {
            try
            {
                return dao.GetWithdrawMethods(emailaddress);
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
