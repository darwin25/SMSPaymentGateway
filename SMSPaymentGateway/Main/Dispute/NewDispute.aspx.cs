using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SMSPaymentGateway.Models;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;
using CommonFunctions;
using Microsoft.Security.Application;

namespace SMSPaymentGateway.Main.Dispute
{
    public partial class NewDispute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string uniquetransactioncode;
            uniquetransactioncode = Server.UrlDecode(Request.QueryString["utc"]);
            if (this.GetOrderStatus(uniquetransactioncode) == TransactionStatus.TRANSACTION_PENDING_CODE)
            {
                lblErrorMessage.Text = "Cannot open a dispute when payment is still not received";
                errorPanel.Visible = true;
                successPanel.Visible = false;
                return;
            }
            else if (this.GetOrderStatus(uniquetransactioncode) == TransactionStatus.TRANSACTION_CANCELLED_CODE)
            {
                lblErrorMessage.Text = "Cannot open a dispute when order is cancelled";
                errorPanel.Visible = true;
                successPanel.Visible = false;
                return;
            }
            else if (this.GetOrderStatus(uniquetransactioncode) == TransactionStatus.TRANSACTION_EXPIRED_CODE)
            {
                lblErrorMessage.Text = "Cannot open a dispute when order is expired";
                errorPanel.Visible = true;
                successPanel.Visible = false;
                return;
            }
            else
            {
                successPanel.Visible = true;
                errorPanel.Visible = true;
                return;
            }


        }

        private string GetOrderStatus(string uniquetransactioncode)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();

            vo.UniqueTransactionCode = uniquetransactioncode;

            return doAction.GetOrderStatus(vo).ToString();

        }
    }
}