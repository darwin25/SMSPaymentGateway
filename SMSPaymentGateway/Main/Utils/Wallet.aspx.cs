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
    public partial class Wallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            af.detectBrowser(this.Page, browser);

            if (!(Page.IsPostBack))
            {
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

            

        }
    }
}