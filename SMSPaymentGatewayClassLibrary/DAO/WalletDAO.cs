using System.Data;
using DBDataProvider;
using MySql.Data.MySqlClient;
using Web.ValueObjects;

namespace Web.DAO
{
    public class WalletDAO
    {
        //DaoObjectInterface
        public WalletDAO()
        {
        }

        #region "DAOObjectInterface Members"

        public object AddFundsToWallet(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            WalletVO vo = (WalletVO)obj;

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("customerid", MySqlDbType.VarChar);
            @params[0].Value = vo.CustomerID;

            @params[1] = new MySqlParameter("amount", MySqlDbType.Float);
            @params[1].Value = vo.FundingAmount;

            @params[2] = new MySqlParameter("result", MySqlDbType.VarChar, 12);
            @params[2].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("AddFundsToWallet", CommandType.StoredProcedure, @params);

                return @params[2].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public DataSet GetFundingDetails(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            WalletVO vo = (WalletVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[0].Value = vo.UniqueTransactionCode;

            @params[1] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[1].Value = vo.EmailAddress1;


            try
            {
                DataSet ds = sqldb.FillDataset("GetFundingDetails", CommandType.StoredProcedure, @params);

                return ds;

            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public object AssignPaymentToFunding(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            WalletVO vo = (WalletVO)obj;

            MySqlParameter[] @params = new MySqlParameter[4];

            @params[0] = new MySqlParameter("customerid", MySqlDbType.VarChar);
            @params[0].Value = vo.CustomerID;

            @params[1] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[1].Value = vo.UniqueTransactionCode;

            @params[2] = new MySqlParameter("paymentreferenceno", MySqlDbType.VarChar);
            @params[2].Value = vo.RemittanceReferenceNumber;

            @params[3] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[3].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("AssignPaymentToFunding", CommandType.StoredProcedure, @params);

                return @params[3].Value;

            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public object VerifyPaymentAndFundingAmount(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            WalletVO vo = (WalletVO)obj;

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("remittancereferencenumber", MySqlDbType.VarChar);
            @params[0].Value = vo.RemittanceReferenceNumber;

            @params[1] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[1].Value = vo.UniqueTransactionCode;

            @params[2] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[2].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("VerifyPaymentAndFundingAmount", CommandType.StoredProcedure, @params);

                return @params[2].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetWithdrawMethods(string emailaddress)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());


            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("emailaddress", MySqlDbType.VarChar);
            @params[0].Value = emailaddress;


            try
            {
                DataSet ds = sqldb.FillDataset("GetWithdrawMethods", CommandType.StoredProcedure, @params);

                return ds;

            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        #endregion
    }
}
