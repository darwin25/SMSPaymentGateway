
using System.Data;
using DBDataProvider;
using MySql.Data.MySqlClient;
using Web.ValueObjects;
namespace Web.DAO
{
    public class UsersDAO
    {

        //DaoObjectInterface
        public UsersDAO()
        {
        }

        #region "DaoObjectInterface Members"

        public object CreateCustomer(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CreateCustomer", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object CustomerRegistration(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[4];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("password", MySqlDbType.VarChar);
            @params[1].Value = vo.UserPassword;

            @params[2] = new MySqlParameter("cellphone", MySqlDbType.VarChar);
            @params[2].Value = vo.MobileNumber;

            @params[3] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[3].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CustomerRegistration", CommandType.StoredProcedure, @params);

                return @params[3].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object IsEmailConfirmed(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("IsEmailConfirmed", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object MerchantRegistration(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[17];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("password", MySqlDbType.VarChar);
            @params[1].Value = vo.UserPassword;

            @params[2] = new MySqlParameter("cellphone", MySqlDbType.VarChar);
            @params[2].Value = vo.MobileNumber;

            @params[3] = new MySqlParameter("firstname", MySqlDbType.VarChar);
            @params[3].Value = vo.FirstName;

            @params[4] = new MySqlParameter("middlename", MySqlDbType.VarChar);
            @params[4].Value = vo.MiddleName;

            @params[5] = new MySqlParameter("lastname", MySqlDbType.VarChar);
            @params[5].Value = vo.LastName;

            @params[6] = new MySqlParameter("businessname", MySqlDbType.VarChar);
            @params[6].Value = vo.BusinessName;

            @params[7] = new MySqlParameter("typeofbusiness", MySqlDbType.VarChar);
            @params[7].Value = vo.BusinessType;

            @params[8] = new MySqlParameter("websiteurl", MySqlDbType.VarChar);
            @params[8].Value = vo.WebsiteURL;

            @params[9] = new MySqlParameter("businessregistrationno", MySqlDbType.VarChar);
            @params[9].Value = vo.BusinessRegistrationNumber;

            @params[10] = new MySqlParameter("taxidno", MySqlDbType.VarChar);
            @params[10].Value = vo.TaxIdentificationNumber;

            @params[11] = new MySqlParameter("businessphoneno", MySqlDbType.VarChar);
            @params[11].Value = vo.Telephone;

            @params[12] = new MySqlParameter("businessaddress", MySqlDbType.VarChar);
            @params[12].Value = vo.Address;

            @params[13] = new MySqlParameter("province", MySqlDbType.VarChar);
            @params[13].Value = vo.Province;

            @params[14] = new MySqlParameter("town", MySqlDbType.VarChar);
            @params[14].Value = vo.Town;

            @params[15] = new MySqlParameter("zipcode", MySqlDbType.VarChar);
            @params[15].Value = vo.ZipCode;

            @params[16] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[16].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("MerchantRegistration", CommandType.StoredProcedure, @params);

                return @params[16].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }


        public object CreateVerificationCode(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CreateVerificationCode", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public object CustomerConfirmEmailAddress(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("verificationid", MySqlDbType.VarChar);
            @params[0].Value = vo.AuthenticationCode;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 50);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CustomerConfirmEmailAddress", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public object UserLoginViaWeb(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[4];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("password", MySqlDbType.VarChar);
            @params[1].Value = vo.UserPassword;

            @params[2] = new MySqlParameter("ipaddress", MySqlDbType.VarChar);
            @params[2].Value = vo.IPAddress;

            @params[3] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[3].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("UserLoginViaWeb", CommandType.StoredProcedure, @params);

                return @params[3].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object Generate2FACode(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 6);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("Generate2FACode", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object Verify2FACode(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("2facode", MySqlDbType.VarChar);
            @params[1].Value = vo.AuthenticationCode;

            @params[2] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[2].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("Verify2FACode", CommandType.StoredProcedure, @params);

                return @params[2].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public object GetUserValues(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("authorizationstatus", MySqlDbType.VarChar);
            @params[1].Value = vo.AuthorizationStatus;

            try
            {
                DataSet ds = sqldb.FillDataset("GetUserValues", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public object GetCustomerInformation(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("authorizationstatus", MySqlDbType.VarChar);
            @params[1].Value = vo.AuthorizationStatus;

            try
            {
                DataSet ds = sqldb.FillDataset("GetCustomerInformation", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public DataSet GetSellerDetails(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("friendlyurlname", MySqlDbType.VarChar);
            @params[0].Value = vo.FriendlyURLName;

            try
            {
                DataSet ds = sqldb.FillDataset("GetSellerDetails", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetCustomerDetails(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            try
            {
                DataSet ds = sqldb.FillDataset("GetCustomerDetails", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object GetCustomerType(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("GetCustomerType", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }

        public object GetCustomerID(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("customeremailadress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 10);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("GetCustomerID", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }



        }
        public object RequestToken(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;


            MySqlParameter[] @params = new MySqlParameter[7];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("password", MySqlDbType.VarChar);
            @params[1].Value = vo.UserPassword;

            @params[2] = new MySqlParameter("ipaddress", MySqlDbType.VarChar);
            @params[2].Value = vo.IPAddress;

            @params[3] = new MySqlParameter("datetimeloggedin", MySqlDbType.DateTime);
            @params[3].Value = vo.DateValue1;

            @params[4] = new MySqlParameter("certificate", MySqlDbType.VarChar);
            @params[4].Value = vo.Certificate;

            @params[5] = new MySqlParameter("url", MySqlDbType.VarChar);
            @params[5].Value = vo.URL;

            @params[6] = new MySqlParameter("Result", MySqlDbType.VarChar, 16);
            @params[6].Direction = ParameterDirection.Output;

            try
            {
                sqldb.ExecuteReader("LoginFromWebService", CommandType.StoredProcedure, @params);

                return @params[6].Value;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public object ValidateToken(string tokenid)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("tokenid", MySqlDbType.VarChar);
            @params[0].Value = tokenid;

            @params[1] = new MySqlParameter("Result", MySqlDbType.VarChar, 16);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                sqldb.ExecuteReader("VerifyIfTokenIsValid", CommandType.StoredProcedure, @params);

                return @params[1].Value;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetProvince()
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());


            try
            {
                DataSet ds = sqldb.FillDataset("GetProvince", CommandType.StoredProcedure);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetTown(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("province", MySqlDbType.VarChar);
            @params[0].Value = vo.Province;

            try
            {
                DataSet ds = sqldb.FillDataset("GetTown", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public object CheckIfUserExists(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CheckIfUserExists", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }


        public object UpdateCustomerDetails(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[10];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("firstname", MySqlDbType.VarChar);
            @params[1].Value = vo.FirstName;

            @params[2] = new MySqlParameter("middlename", MySqlDbType.VarChar);
            @params[2].Value = vo.MiddleName;

            @params[3] = new MySqlParameter("lastname", MySqlDbType.VarChar);
            @params[4].Value = vo.LastName;

            @params[4] = new MySqlParameter("friendlyurlname", MySqlDbType.VarChar);
            @params[4].Value = vo.FriendlyURLName;

            @params[5] = new MySqlParameter("mobilenumber", MySqlDbType.VarChar);
            @params[5].Value = vo.MobileNumber;

            @params[6] = new MySqlParameter("address", MySqlDbType.VarChar);
            @params[6].Value = vo.Address;

            @params[7] = new MySqlParameter("province", MySqlDbType.VarChar);
            @params[7].Value = vo.Province;

            @params[8] = new MySqlParameter("town", MySqlDbType.VarChar);
            @params[8].Value = vo.Town;

            @params[9] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[9].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("UpdateCustomerDetails", CommandType.StoredProcedure, @params);

                return @params[9].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public object CheckIfFriendlyNameExists(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("friendlyurlname", MySqlDbType.VarChar);
            @params[0].Value = vo.FriendlyURLName;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 40);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CheckIfFriendlyNameExists", CommandType.StoredProcedure, @params);

                return @params[1].Value;

            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetPaymentOptions()
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            try
            {
                DataSet ds = sqldb.FillDataset("GetPaymentOptions", CommandType.StoredProcedure);

                return ds;

            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public DataSet GetBanks(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("paymentoption", MySqlDbType.VarChar);
            @params[0].Value = vo.PaymentOption;

            try
            {
                DataSet ds = sqldb.FillDataset("GetBanks", CommandType.StoredProcedure, @params);

                return ds;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public object GetRecepientName(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            UsersVO vo = (UsersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 50);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("GetRecepientName", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        #endregion
    }

}