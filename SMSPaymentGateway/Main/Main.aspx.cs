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
    public partial class Main : System.Web.UI.Page
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
                    Response.Redirect("~/Main/Main2.aspx");
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

        private string  GetCustomerType(string emailaddress)
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
            int pendingorders;
            int escroworders;
            int receivedorders;
            int cancelledorders;
            int expiredorders;
            string fromdate;
            string todate;

            fromdate = txtDateFrom.Text;
            todate = txtDateTo.Text;

            ds = doAction.GetMerchantDashboard(emailaddress, Convert.ToDateTime(fromdate), Convert.ToDateTime(todate));

            if (ds.Tables[0].Rows.Count > 0)
            {
               walletbalance = Convert.ToDouble(ds.Tables[0].Rows[0]["walletbalance"].ToString());
               pendingorders = Convert.ToInt32(ds.Tables[0].Rows[0]["pendingorders"].ToString());
               escroworders = Convert.ToInt32(ds.Tables[0].Rows[0]["escroworders"].ToString());
               receivedorders = Convert.ToInt32(ds.Tables[0].Rows[0]["receivedorders"].ToString());
               cancelledorders = Convert.ToInt32(ds.Tables[0].Rows[0]["cancelledorders"].ToString());
               expiredorders = Convert.ToInt32(ds.Tables[0].Rows[0]["expiredorders"].ToString());

               lblWalletBalance.Text = "Php " + String.Format("{0:0,0.00}", walletbalance);

                //pending
               if (pendingorders > 0)
               {
                   lblPendingOrders.Text = "<a href=Business/Pending.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Pending Orders <span class=badge-pending>" + pendingorders + "</span></a>";
               }
               else
               {
                   lblPendingOrders.Text = "<a href=Business/Pending.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Pending Orders</a>";
               }

               //on escrow
               if (escroworders > 0)
               {
                   lblEscrowOrders.Text = "<a href=Business/Escrow.aspx?fromdate=" + fromdate + "&todate=" + todate + ">On Escrow <span class=badge-escrow>" + escroworders + "</span></a>";
               }
               else
               {
                   lblEscrowOrders.Text = "<a href=Business/Escrow.aspx?fromdate=" + fromdate + "&todate=" + todate + ">On Escrow</a>";
               }

               //received
               if (receivedorders > 0)
               {
                   lblReceivedOrders.Text = "<a href=Business/Received.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Received Payment <span class=badge-received>" + receivedorders + "</span></a>";
               }
               else
               {
                   lblReceivedOrders.Text = "<a href=Business/Received.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Received Payment</a>";
               }
             
               //cancelled
               if (cancelledorders > 0)
               {
                   lblCancelledOrders.Text = "<a href=Business/Cancelled.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Cancelled Orders <span class=badge-cancelled>" + cancelledorders + "</span></a>";
               }
               else
               {
                   lblCancelledOrders.Text = "<a href=Business/Cancelled.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Cancelled Orders</a>";
               }

               //expired
               if (expiredorders > 0)
               {
                   lblExpiredOrders.Text = "<a href=Business/Expired.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Expired Orders <span class=badge-expired>" + expiredorders + "</span></a>";
               }
               else
               {
                   lblExpiredOrders.Text = "<a href=Business/Expired.aspx?fromdate=" + fromdate + "&todate=" + todate + ">Expired Orders</a>";
               }


            }


        }
    }
}