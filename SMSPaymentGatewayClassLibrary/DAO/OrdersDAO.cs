
using System.Data;
using DBDataProvider;
using Web.ValueObjects;
using MySql.Data.MySqlClient;
using System;
namespace Web.DAO
{

    public class OrdersDAO
    {
        //DaoObjectInterface
        public OrdersDAO()
        {
        }


        #region "DaoObjectInterface Members"

        public object CreateOrder(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[14];

            @params[0] = new MySqlParameter("receiveremailaddress", MySqlDbType.VarChar);
            @params[0].Value = vo.EmailAddress1;

            @params[1] = new MySqlParameter("buyeremailaddress", MySqlDbType.VarChar);
            @params[1].Value = vo.EmailAddress2;

            @params[2] = new MySqlParameter("buyerfirstname", MySqlDbType.VarChar);
            @params[2].Value = vo.FirstName;

            @params[3] = new MySqlParameter("buyermiddlename", MySqlDbType.VarChar);
            @params[3].Value = vo.MiddleName;

            @params[4] = new MySqlParameter("buyerlastname", MySqlDbType.VarChar);
            @params[4].Value = vo.LastName;

            @params[5] = new MySqlParameter("buyeraddress", MySqlDbType.VarChar);
            @params[5].Value = vo.Address;

            @params[6] = new MySqlParameter("buyerprovince", MySqlDbType.VarChar);
            @params[6].Value = vo.Province;

            @params[7] = new MySqlParameter("buyertown", MySqlDbType.VarChar);
            @params[7].Value = vo.Town;

            @params[8] = new MySqlParameter("buyercellphoneno", MySqlDbType.VarChar);
            @params[8].Value = vo.MobileNumber;

            @params[9] = new MySqlParameter("orderamount", MySqlDbType.Float);
            @params[9].Value = vo.OrderAmount;

            @params[10] = new MySqlParameter("orderdescription", MySqlDbType.VarChar);
            @params[10].Value = vo.OrderDescription;

            @params[11] = new MySqlParameter("orderskucode", MySqlDbType.VarChar);
            @params[11].Value = vo.OrderSKU;

            @params[12] = new MySqlParameter("tokenid", MySqlDbType.VarChar);
            @params[12].Value = vo.TokenID;

            @params[13] = new MySqlParameter("result", MySqlDbType.VarChar, 12);
            @params[13].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CreateOrder", CommandType.StoredProcedure, @params);

                return @params[13].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }

        public object CreateOrder2(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[12];

            @params[0] = new MySqlParameter("friendlyurlname", MySqlDbType.VarChar);
            @params[0].Value = vo.FriendlyURLName;

            @params[1] = new MySqlParameter("buyeremailaddress", MySqlDbType.VarChar);
            @params[1].Value = vo.EmailAddress2;

            @params[2] = new MySqlParameter("buyerfirstname", MySqlDbType.VarChar);
            @params[2].Value = vo.FirstName;

            @params[3] = new MySqlParameter("buyermiddlename", MySqlDbType.VarChar);
            @params[3].Value = vo.MiddleName;

            @params[4] = new MySqlParameter("buyerlastname", MySqlDbType.VarChar);
            @params[4].Value = vo.LastName;

            @params[5] = new MySqlParameter("buyeraddress", MySqlDbType.VarChar);
            @params[5].Value = vo.Address;

            @params[6] = new MySqlParameter("buyerprovince", MySqlDbType.VarChar);
            @params[6].Value = vo.Province;

            @params[7] = new MySqlParameter("buyertown", MySqlDbType.VarChar);
            @params[7].Value = vo.Town;

            @params[8] = new MySqlParameter("buyercellphoneno", MySqlDbType.VarChar);
            @params[8].Value = vo.MobileNumber;

            @params[9] = new MySqlParameter("orderamount", MySqlDbType.Float);
            @params[9].Value = vo.OrderAmount;

            @params[10] = new MySqlParameter("orderdescription", MySqlDbType.VarChar);
            @params[10].Value = vo.OrderDescription;

            @params[11] = new MySqlParameter("result", MySqlDbType.VarChar, 12);
            @params[11].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("CreateOrder2", CommandType.StoredProcedure, @params);

                return @params[11].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object UpdateOrder(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[6];

            @params[0] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[0].Value = vo.UniqueTransactionCode;

            @params[1] = new MySqlParameter("deliveryprovidername", MySqlDbType.VarChar);
            @params[1].Value = vo.DeliveryProvider;

            @params[2] = new MySqlParameter("trackingnumber", MySqlDbType.VarChar);
            @params[2].Value = vo.TrackingNumber;

            @params[3] = new MySqlParameter("datesent", MySqlDbType.Date);
            @params[3].Value = vo.DateValue1;

            @params[4] = new MySqlParameter("estimateddateofdelivery", MySqlDbType.Date);
            @params[4].Value = vo.DateValue2;

            @params[5] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[5].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("UpdateOrder", CommandType.StoredProcedure, @params);

                return @params[5].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }

        public object GetOrderStatus(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[0].Value = vo.UniqueTransactionCode;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 2);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("GetOrderStatus", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetOrderDetails(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[0].Value = vo.UniqueTransactionCode;

            try
            {
                DataSet ds = sqldb.FillDataset("GetOrderDetails", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetOrderDetails2(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[1];

            @params[0] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[0].Value = vo.UniqueTransactionCode;

            try
            {
                DataSet ds = sqldb.FillDataset("GetOrderDetails2", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object GetRemittanceReferenceNumberStatus(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter("remittancereferencenumber", MySqlDbType.VarChar);
            @params[0].Value = vo.RemittanceReferenceNumber;

            @params[1] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("GetRemittanceReferenceNumberStatus", CommandType.StoredProcedure, @params);

                return @params[1].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }

        public object VerifyPaymentAndOrderAmount(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("remittancereferencenumber", MySqlDbType.VarChar);
            @params[0].Value = vo.RemittanceReferenceNumber;

            @params[1] = new MySqlParameter("uniquetransactionid", MySqlDbType.VarChar);
            @params[1].Value = vo.UniqueTransactionCode;

            @params[2] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[2].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("VerifyPaymentAndOrderAmount", CommandType.StoredProcedure, @params);

                return @params[2].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public object AssignPaymentToOrder(object obj)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());
            OrdersVO vo = (OrdersVO)obj;

            MySqlParameter[] @params = new MySqlParameter[4];

            @params[0] = new MySqlParameter("buyercustomerid", MySqlDbType.VarChar);
            @params[0].Value = vo.BuyerCustomerID;

            @params[1] = new MySqlParameter("uniquetransactioncode", MySqlDbType.VarChar);
            @params[1].Value = vo.UniqueTransactionCode;

            @params[2] = new MySqlParameter("remittancereferenceno", MySqlDbType.VarChar);
            @params[2].Value = vo.RemittanceReferenceNumber;

            @params[3] = new MySqlParameter("result", MySqlDbType.VarChar, 1);
            @params[3].Direction = ParameterDirection.Output;

            try
            {
                IDataReader dr = sqldb.ExecuteReader("AssignPaymentToOrder", CommandType.StoredProcedure, @params);

                return @params[3].Value;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }
        }

        public DataSet GetOrders(string selleremailaddress, string orderstatus, DateTime fromdate, DateTime todate)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("selleremailaddress", MySqlDbType.VarChar);
            @params[0].Value = selleremailaddress;

            @params[1] = new MySqlParameter("fromdate", MySqlDbType.Date);
            @params[1].Value = fromdate;

            @params[2] = new MySqlParameter("todate", MySqlDbType.Date);
            @params[2].Value = todate;

            try
            {
                DataSet ds = sqldb.FillDataset("GetOrders_" + orderstatus, CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }

        public DataSet GetBuyerOrders(string buyeremailaddress, DateTime fromdate, DateTime todate)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("buyeremailaddress", MySqlDbType.VarChar);
            @params[0].Value = buyeremailaddress;

            @params[1] = new MySqlParameter("fromdate", MySqlDbType.Date);
            @params[1].Value = fromdate;

            @params[2] = new MySqlParameter("todate", MySqlDbType.Date);
            @params[2].Value = todate;

            try
            {
                DataSet ds = sqldb.FillDataset("GetBuyerOrders", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }

        public object GetPayments(string customeremailaddress, string paymentmode, System.DateTime date1, System.DateTime date2)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("customeremailaddress", MySqlDbType.VarChar);
            @params[0].Value = customeremailaddress;

            @params[1] = new MySqlParameter("datefrom", MySqlDbType.Date);
            @params[1].Value = date1;

            @params[2] = new MySqlParameter("dateto", MySqlDbType.Date);
            @params[2].Value = date2;

            try
            {
                DataSet ds = sqldb.FillDataset("GetPayments" + paymentmode, CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }


        }


        public DataSet GetMerchantDashboard(string selleremailaddress, DateTime fromdate, DateTime todate)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("selleremailaddress", MySqlDbType.VarChar);
            @params[0].Value = selleremailaddress;

            @params[1] = new MySqlParameter("fromdate", MySqlDbType.Date);
            @params[1].Value = fromdate;

            @params[2] = new MySqlParameter("todate", MySqlDbType.Date);
            @params[2].Value = todate;

            try
            {
                DataSet ds = sqldb.FillDataset("GetMerchantDashboard", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }

        public DataSet GetBuyerDashboard(string buyeremailaddress, DateTime fromdate, DateTime todate)
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());

            MySqlParameter[] @params = new MySqlParameter[3];

            @params[0] = new MySqlParameter("buyeremailaddress", MySqlDbType.VarChar);
            @params[0].Value = buyeremailaddress;

            @params[1] = new MySqlParameter("fromdate", MySqlDbType.Date);
            @params[1].Value = fromdate;

            @params[2] = new MySqlParameter("todate", MySqlDbType.Date);
            @params[2].Value = todate;

            try
            {
                DataSet ds = sqldb.FillDataset("GetBuyerDashboard", CommandType.StoredProcedure, @params);

                return ds;


            }
            catch (System.Exception ex)
            {
                throw ex;

            }

        }
        public DataSet GetDeliveryProviders()
        {
            ConnValues ConnStr = new ConnValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.conn());



            try
            {
                DataSet ds = sqldb.FillDataset("GetDeliveryProviders", CommandType.TableDirect);

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