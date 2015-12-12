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
using Microsoft.Security.Application;

namespace SMSPaymentGateway.Main.Utils
{
    public partial class MyFunding : System.Web.UI.Page
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
            if (!(Page.IsPostBack))
            {
                string uniquetransactioncode;
                uniquetransactioncode = Server.UrlDecode(Request.QueryString["utc"]);
                txtEmailAddress.Value = Context.User.Identity.GetUserName();

                this.GetFundingDetails(uniquetransactioncode, txtEmailAddress.Value);

            }
        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();

            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        private void GetFundingDetails(string uniquetransactioncode, string emailaddress)
        {
            WalletVO vo = new WalletVO();
            GetWalletAction doAction = new GetWalletAction();
            AppFunctions af = new AppFunctions();

            vo.EmailAddress1 = emailaddress;
            vo.UniqueTransactionCode = uniquetransactioncode;

            DataSet ds = doAction.GetFundingDetails(vo);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFundingStatus.Text = af.DisplayText(ds.Tables[0].Rows[0]["fundingstatus"].ToString()).ToUpper();
                txtCustomerID.Value = af.DisplayText(ds.Tables[0].Rows[0]["customerid"].ToString());
                txtUniqueTransactionCode.Text = af.DisplayText(ds.Tables[0].Rows[0]["uniquetransactioncode"].ToString());                
                txtFundingAmount.Text = "Php " + af.FormatNumberWithComma(ds.Tables[0].Rows[0]["fundingamount"].ToString());
                txtDateTimeCreated.Text = ds.Tables[0].Rows[0]["fundingdatetimecreated"].ToString();
                txtDateTimePOC.Text = ds.Tables[0].Rows[0]["fundingdatetimereceived"].ToString();
                txtDateTimeExpired.Text = ds.Tables[0].Rows[0]["fundingdatetimeexpired"].ToString();
                txtPaymentReferenceNumber.Text = af.DisplayText(ds.Tables[0].Rows[0]["paymentreferencenumber"].ToString());
            }
            else
            {
                lblMessage.Text = MessageAlert.NO_RECORD_FOUND;
            }

        }

        private string GetPaymentReferenceNumberStatus(string paymentreferencenumber)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();

            vo.RemittanceReferenceNumber = paymentreferencenumber;

            return doAction.GetRemittanceReferenceNumberStatus(vo).ToString();
        }

        private string VerifyPaymentAndFundingAmount(string paymentreferencenumber, string uniquetransactioncode)
        {
            WalletVO vo = new WalletVO();
            GetWalletAction doAction = new GetWalletAction();

            vo.RemittanceReferenceNumber = paymentreferencenumber;
            vo.UniqueTransactionCode = uniquetransactioncode;

            return doAction.VerifyPaymentAndFundingAmount(vo).ToString();

        }

        private string AssignPaymentToFunding(string customerid, string paymentreferencenumber, string uniquetransactioncode)
        {
            WalletVO vo = new WalletVO();
            GetWalletAction doAction = new GetWalletAction();

            vo.CustomerID = customerid;
            vo.RemittanceReferenceNumber = paymentreferencenumber;
            vo.UniqueTransactionCode = uniquetransactioncode;

            return doAction.AssignPaymentToFunding(vo).ToString();
        }


        protected void btnPayOrder_Click(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();

            string customerid = af.StripHTML(txtCustomerID.Value);
            string paymentreferencenumber = af.StripHTML(txtPaymentReferenceNumber.Text);
            string uniquetrannsacioncode = af.StripHTML(txtUniqueTransactionCode.Text);

            if (!string.IsNullOrEmpty(paymentreferencenumber))
            {
                if (this.GetPaymentReferenceNumberStatus(paymentreferencenumber).ToString() == RRNStatus.UNASSIGNED)
                {
                    string paymentandfundingamountstatus = this.VerifyPaymentAndFundingAmount(paymentreferencenumber, uniquetrannsacioncode).ToString();

                    if (paymentandfundingamountstatus == PaymentAmount.PAYMENTAMOUNT_EQUALS_FUNDINGAMOUNT)
                    {
                        string result = this.AssignPaymentToFunding(customerid, paymentreferencenumber, uniquetrannsacioncode).ToString();

                        if (result == ActionResult.ACTION_SUCCESSFUL)
                        {
                            lblMessage.Text = MessageAlert.PAYMENT_FUNDING_SUCCESSFUL;
                            lblMessage.ForeColor = System.Drawing.Color.Blue;
                            lblMessage.Font.Size = 20;
                            txtFundingStatus.Text = TransactionStatus.TRANSACTION_PAID.ToUpper();
                        }
                        else
                        {
                            lblMessage.Text = MessageAlert.PAYMENT_FUNDING_FAILED;
                        }
                    }
                    else if (paymentandfundingamountstatus == PaymentAmount.PAYMENTAMOUNT_GREATER_THAN_FUNDINGAMOUNT)
                    {
                        //btnOptions.Enabled = true;
                        lblMessage.Text = "Payment amount is greater than funding amount."; // Click the MORE button for options";
                        //btnOptions.Font.Bold = true;
                    }
                    else if (paymentandfundingamountstatus == PaymentAmount.PAYMENTAMOUNT_GREATER_THAN_FUNDINGAMOUNT)
                    {
                        //btnOptions.Enabled = true;
                        lblMessage.Text = "Payment amount is less than funding amount.";// Click the MORE button for options";
                        //btnOptions.Font.Bold = true;
                    }

                }

                else
                {
                    lblMessage.Text = MessageAlert.PAYMENT_REFERENCE_NUMBER_NOT_EXIST + ". " + MessageAlert.PAYMENT_FUNDING_FAILED;

                }

            }

        }

    }
}