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

namespace SMSPaymentGateway.Main.Utils
{
    public partial class AddFunds : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
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
            else
            {
                MasterPageFile = "~/Site.Master";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            af.detectBrowser(this.Page, browser);

            if (!(Page.IsPostBack))
            {

                txtCustomerID.Value = this.GetCustomerID(Context.User.Identity.GetUserName());
                txtPaymentAmount.Text = "0.00";
            }
        }

        protected void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();

            if (string.IsNullOrEmpty(this.txtPaymentAmount.Text))
            {
                txtPaymentAmount.Text = "0.00";
                lblPaymentAmountValidator.Text = MessageAlert.PAYMENT_AMOUNT_REQUIRED;
            }
            else
            {

                double num;
                if (double.TryParse(txtPaymentAmount.Text, out num) == true && Convert.ToDouble(txtPaymentAmount.Text) > 0)
                {
                    txtPaymentAmount.Text = string.Format("{0:n2}", Convert.ToDecimal(txtPaymentAmount.Text));
                }

            }

        }

        private bool ValidateInput()
        {
            bool functionReturnValue = false;
            AppFunctions af = new AppFunctions();
            
            if (string.IsNullOrEmpty(this.txtPaymentAmount.Text))
            {
                this.txtPaymentAmount.Text = "0.00";
                this.lblPaymentAmountValidator.Text = MessageAlert.PAYMENT_AMOUNT_REQUIRED;

                return functionReturnValue;

            }
                         
            else
            {
                functionReturnValue = true;
            }

            return functionReturnValue;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string uniquetransactioncode;
            if (ValidateInput() == true && Convert.ToDouble(txtPaymentAmount.Text) > 0)
            {

                GetWalletAction doAction = new GetWalletAction();
                WalletVO vo = new WalletVO();
                AppFunctions af = new AppFunctions();

                vo.CustomerID = txtCustomerID.Value;
                vo.FundingAmount = Convert.ToDouble(txtPaymentAmount.Text);


                uniquetransactioncode = doAction.AddFundsToWallet(vo).ToString();
                
                SendUTCToCustomerViaEmail(Context.User.Identity.GetUserName(), uniquetransactioncode);

                Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/Success.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode));

            }
            else
            {
                Message.Text = MessageAlert.PAYMENT_AMOUNT_REQUIRED;
            }

        }
        private string GetCustomerID(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            
            vo.EmailAddress1 = emailaddress;

            return doAction.GetCustomerID(vo).ToString();
        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }


        private void SendUTCToCustomerViaEmail(string receipient, string uniquetransactioncode)
        {
            AppFunctions af = new AppFunctions();

            string subject = "Your Bayan Pay Wallet Funding";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Click the link below to pay your your wallet funding." +
                Environment.NewLine +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Utils/MyFunding.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);


        }
    }
}