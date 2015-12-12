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
    public partial class AddWithdrawMethod : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                this.GetPaymentOption();
            }
            
        }

        protected void ddlPaymentOption_TextChanged(object sender, EventArgs e)
        {
            this.GetBanks(this.ddlPaymentOption.Text);
        }

        protected void txtBankAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void GetPaymentOption()
        {
            GetUserAction doAction = new GetUserAction();
            DataSet ds = new DataSet();

            ds = doAction.GetPaymentOptions();

            ddlPaymentOption.Items.Add("");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.ddlPaymentOption.Items.Add(row["paymentoption"].ToString());
            }

            ds.Dispose();
        }

        private void GetBanks(string paymentoption)
        {
            ddlBank.Items.Clear();

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            DataSet ds = new DataSet();

            vo.PaymentOption = paymentoption;

            ds = doAction.GetBanks(vo);

            ddlBank.Items.Add("");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.ddlBank.Items.Add(row["bankname"].ToString());
            }

            ds.Dispose();
        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}