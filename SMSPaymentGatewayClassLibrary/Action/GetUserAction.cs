
using System;
using System.Data;
using Web.DAO;
using Web.Constants;
using Web.Helper;
using DBDataProvider;


namespace Web.Actions
{
    [Serializable()]
    public class GetUserAction
    {
        //Inherits ActionObjectInterface

        public UsersDAO dao = new UsersDAO();
        public GetUserAction()
        {
        }

        #region "ActionObjectInterface Members"


        public object CreateCustomer(object obj)
        {
            try
            {
                return dao.CreateCustomer(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object CustomerRegistration(object obj)
        {
            try
            {
                return dao.CustomerRegistration(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object IsEmailConfirmed(object obj)
        {
            try
            {
                return dao.IsEmailConfirmed(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object MerchantRegistration(object obj)
        {
            try
            {
                return dao.MerchantRegistration(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object CreateVerificationCode(object obj)
        {
            try
            {
                return dao.CreateVerificationCode(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ADD);
            }

            return null;
        }

        public object CustomerConfirmEmailAddress(object obj)
        {
            try
            {
                return dao.CustomerConfirmEmailAddress(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object UserLoginViaWeb(object obj)
        {
            try
            {
                return dao.UserLoginViaWeb(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object Generate2FACode(object obj)
        {
            try
            {
                return dao.Generate2FACode(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object Verify2FACode(object obj)
        {
            try
            {
                return dao.Verify2FACode(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.PARSING);
            }

            return null;
        }

        public object GetUserValues(object obj)
        {
            try
            {
                return dao.GetUserValues(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object GetCustomerInformation(object obj)
        {
            try
            {
                return dao.GetCustomerInformation(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetSellerDetails(object obj)
        {
            try
            {
                return dao.GetSellerDetails(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetCustomerDetails(object obj)
        {
            try
            {
                return dao.GetCustomerDetails(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }


        public object GetCustomerType(object objInput)
        {
            try
            {
                return dao.GetCustomerType(objInput);
            }
            catch (System.Exception ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object GetCustomerID(object objInput)
        {
            try
            {
                return dao.GetCustomerID(objInput);
            }
            catch (System.Exception ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object RequestToken(object objInput)
        {
            try
            {
                return dao.RequestToken(objInput);
            }
            catch (System.Exception ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public object ValidateToken(string tokenid)
        {
            try
            {
                return dao.ValidateToken(tokenid);
            }
            catch (System.Exception ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.ACTION);
            }

            return null;
        }

        public DataSet GetProvince()
        {
            try
            {
                return dao.GetProvince();
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetTown(object obj)
        {
            try
            {
                return dao.GetTown(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object CheckIfUserExists(object obj)
        {
            try
            {
                return dao.CheckIfUserExists(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public object UpdateCustomerDetails(object obj)
        {
            try
            {
                return dao.UpdateCustomerDetails(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }


        public object CheckIfFriendlyNameExists(object obj)
        {
            try
            {
                return dao.CheckIfFriendlyNameExists(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetPaymentOptions()
        {
            try
            {
                return dao.GetPaymentOptions();
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public DataSet GetBanks(object obj)
        {
            try
            {
                return dao.GetBanks(obj);
            }
            catch (SqlDatabaseException ex)
            {
                ExceptionHelper.ExceptionHandler(ex, ErrorType.SEARCH);
            }

            return null;
        }

        public Object GetRecepientName(object obj)
        {
            try
            {
                return dao.GetRecepientName(obj);
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
