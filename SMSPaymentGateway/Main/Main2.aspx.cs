using System;
using System.Data;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNet.Identity;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;
using CommonFunctions;

namespace SMSPaymentGateway.Main
{
    public partial class Main2 : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string customer_type = this.GetCustomerType(Context.User.Identity.GetUserName());

                if (customer_type == CustomerType.BUSINESS)
                {
                    MasterPageFile = "~/Main/mainMaster.Master";

                }
                else if (customer_type == CustomerType.INDIVIDUAL)
                {
                    MasterPageFile = "~/Main/mainMaster2.Master";
                }
            }

            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {

            txtDateFrom.Text = DateTime.Today.Date.AddDays(-30).ToString("yyyy-MM-dd");
            txtDateTo.Text = DateTime.Today.Date.ToString("yyyy-MM-dd");

            string emailaddress = Context.User.Identity.GetUserName();
            this.GetMerchantDashBoard(emailaddress);

        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        private void GetMerchantDashBoard(string emailaddress)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();
            DataSet ds = new DataSet();
            AppFunctions af = new AppFunctions();

            double walletbalance;
            int myorders;            
            string fromdate;
            string todate;

            fromdate = txtDateFrom.Text;
            todate = txtDateTo.Text;

            ds = doAction.GetBuyerDashboard(emailaddress, Convert.ToDateTime(fromdate), Convert.ToDateTime(todate));

            if (ds.Tables[0].Rows.Count > 0)
            {
                walletbalance = Convert.ToDouble(ds.Tables[0].Rows[0]["walletbalance"].ToString());
                myorders = Convert.ToInt32(ds.Tables[0].Rows[0]["myorders"].ToString());
                

                lblWalletBalance.Text = "Php " + String.Format("{0:0,0.00}", walletbalance);

                //pending
                lblMyOrders.Text = "<a href=Buyer/MyOrders.aspx?fromdate=" + fromdate + "&todate=" + todate + ">My Purchases <span class=badge-all>" + myorders + "</span></a>";
                



            }


        }
    }
}