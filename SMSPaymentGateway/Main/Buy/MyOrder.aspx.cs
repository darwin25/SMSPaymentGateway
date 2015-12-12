using System;
using System.Data;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;
using CommonFunctions;
using Microsoft.Security.Application;


namespace SMSPaymentGateway.Main.Buy
{
    public partial class MyOrder : System.Web.UI.Page
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
            if (Page.IsPostBack == false)
            {
                //btnOptions.Attributes.Add("data-target" , myModal.ClientID);
                string uniquetransactioncode;
                uniquetransactioncode = Server.UrlDecode(Request.QueryString["utc"]);
                this.GetOrderDetails(uniquetransactioncode);
            }
        }

        private void GetOrderDetails(string uniquetransactioncode)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();
            AppFunctions af = new AppFunctions();
            DataSet ds = new DataSet();

            vo.UniqueTransactionCode = uniquetransactioncode;
            ds = doAction.GetOrderDetails(vo);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtOrderStatus.Text = af.DisplayText(ds.Tables[0].Rows[0]["orderstatus"].ToString()).ToUpper();
                txtCustomerID.Value = af.DisplayText(ds.Tables[0].Rows[0]["customerid"].ToString());
                txtSellerID.Value = af.DisplayText(ds.Tables[0].Rows[0]["sellerid"].ToString());

                txtCustomerDetails.Text = af.DisplayText(ds.Tables[0].Rows[0]["customername"].ToString()) + "<br/>" + // Environment.NewLine +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customeremailaddress"].ToString()) + "<br/>" + //Environment.NewLine +
                                            af.FormatMobileNumber(ds.Tables[0].Rows[0]["customermobilenumber"].ToString()) + "<br/>" + //Environment.NewLine +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customeraddress"].ToString()) + "<br/>" + //Environment.NewLine +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customertown"].ToString()) + ", " + af.DisplayText(ds.Tables[0].Rows[0]["customerprovince"].ToString());

                //txtSellerDetails.Text = af.DisplayText(ds.Tables[0].Rows[0]["sellername"].ToString()) + "<br/>" + //Environment.NewLine +
                //                                "<b>" + af.DisplayText(ds.Tables[0].Rows[0]["sellerfriendlyurlname"].ToString()) + "</font></b><br/>" +
                //    // af.DisplayText(ds.Tables[0].Rows[0]["selleremailaddress"].ToString()) + "<br/>" + // Environment.NewLine +
                //                                  "Bayan Pay ID: <b>" + af.DisplayText(ds.Tables[0].Rows[0]["customerid"].ToString()) + "</b><br/>" + // Environment.NewLine +
                //                                  af.FormatMobileNumber(ds.Tables[0].Rows[0]["sellermobilenumber"].ToString());

                txtSellerDetails.Text = "<b>" + af.DisplayText(ds.Tables[0].Rows[0]["sellerfriendlyurlname"].ToString()) + "</font></b><br/>" +
                    // af.DisplayText(ds.Tables[0].Rows[0]["selleremailaddress"].ToString()) + "<br/>" + // Environment.NewLine +
                                                                  "Bayan Pay ID: <b>" + af.DisplayText(ds.Tables[0].Rows[0]["sellerid"].ToString()) + "</b><br/>" + // Environment.NewLine +
                                                                  af.FormatMobileNumber(ds.Tables[0].Rows[0]["sellermobilenumber"].ToString());
                txtUniqueTransactionCode.Text = uniquetransactioncode;
                txtOrderDescription.Text = af.DisplayText(ds.Tables[0].Rows[0]["orderdescription"].ToString());
                txtOrderAmount.Text = "Php " + String.Format("{0:0,0.00}", Convert.ToDouble(ds.Tables[0].Rows[0]["orderamount"].ToString()));
                txtDateTimeCreated.Text = ds.Tables[0].Rows[0]["datetimecreated"].ToString();
                txtDateTimePOC.Text = af.IIf(ds.Tables[0].Rows[0]["orderstatus"].ToString() == "Received", ds.Tables[0].Rows[0]["datetimereceived"].ToString(), af.IIf(ds.Tables[0].Rows[0]["orderstatus"].ToString() == "Cancelled", ds.Tables[0].Rows[0]["datetimecancelled"].ToString(), ""));
                lblDateTimePOC.Text = af.IIf(ds.Tables[0].Rows[0]["orderstatus"].ToString() == "Cancelled", "Date / Time Cancelled", "Date / Time Paid");
                txtDateTimeExpired.Text = ds.Tables[0].Rows[0]["datetimeexpired"].ToString();
                txtPaymentReferenceNumber.Text = af.DisplayText(ds.Tables[0].Rows[0]["paymentreferencenumber"].ToString());
            }
            else
            {
                lblMessage.Text = MessageAlert.NO_RECORD_FOUND;
            }

        }

        private string VerifyPaymentAndOrderAmount(string paymentreferencenumber, string uniquetransactioncode)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();

            vo.RemittanceReferenceNumber = paymentreferencenumber;
            vo.UniqueTransactionCode = uniquetransactioncode;

            return doAction.VerifyPaymentAndOrderAmount(vo).ToString();

        }

        private string AssignPaymentToOrder(string buyercustomerid, string paymentreferencenumber, string uniquetransactioncode)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();

            vo.BuyerCustomerID = buyercustomerid;
            vo.RemittanceReferenceNumber = paymentreferencenumber;
            vo.UniqueTransactionCode = uniquetransactioncode;

            return doAction.AssignPaymentToOrder(vo).ToString();
        }


        private string GetPaymentReferenceNumberStatus(string paymentreferencenumber)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();

            vo.RemittanceReferenceNumber = paymentreferencenumber;

            return doAction.GetRemittanceReferenceNumberStatus(vo).ToString();
        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }


        private void SendEmailConfiirmationToBuyer(string receipient, string uniquetransactioncode)
        {
            AppFunctions af = new AppFunctions();

            string subject = "Your payment is received";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Your payment for your order with unique transaction code (UTC)" + uniquetransactioncode + " has been received" +
                Environment.NewLine +
                Environment.NewLine +
                "Click below to view the details of the order." +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/MyOrder.aspx?payee=" + Encoder.UrlEncode(uniquetransactioncode) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);
        }

        private void SendEmailConfiirmationToSeller(string receipient, string uniquetransactioncode)
        {
            AppFunctions af = new AppFunctions();

            string subject = "Order has been paid";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "The payment for order with unique transaction code (UTC) " + uniquetransactioncode + " has been received" +
                Environment.NewLine +
                Environment.NewLine +
                "Click below to view the details of the order." +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/MyOrder.aspx?payee=" + Encoder.UrlEncode(uniquetransactioncode) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);
        }

        protected void btnPayOrder_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                AppFunctions af = new AppFunctions();

                string buyercustomerid = af.StripHTML(txtCustomerID.Value);
                string paymentreferencenumber = af.StripHTML(txtPaymentReferenceNumber.Text);
                string uniquetrannsacioncode = af.StripHTML(txtUniqueTransactionCode.Text);

                //btnOptions.Enabled = true;

                if (!string.IsNullOrEmpty(paymentreferencenumber))
                {
                    if (this.GetPaymentReferenceNumberStatus(paymentreferencenumber).ToString() == RRNStatus.UNASSIGNED)
                    {
                        string paymentandorderamountstatus = VerifyPaymentAndOrderAmount(paymentreferencenumber, uniquetrannsacioncode).ToString();

                        if (paymentandorderamountstatus == PaymentAmount.PAYMENTAMOUNT_EQUALS_ORDERAMOUNT)
                        {
                            string result = this.AssignPaymentToOrder(buyercustomerid, paymentreferencenumber, uniquetrannsacioncode).ToString();

                            if (result == ActionResult.ACTION_SUCCESSFUL)
                            {
                                lblMessage.Text = MessageAlert.PAYMENT_ORDER_SUCCESSFUL;
                                lblMessage.ForeColor = System.Drawing.Color.Blue;
                                lblMessage.Font.Size = 20;
                                txtOrderStatus.Text = TransactionStatus.TRANSACTION_PAID.ToUpper();
                            }
                            else
                            {
                                lblMessage.Text = MessageAlert.PAYMENT_ORDER_FAILED;
                            }
                        }
                        else if (paymentandorderamountstatus == PaymentAmount.PAYMENTAMOUNT_GREATER_THAN_ORDERAMOUNT)
                        {
                            //btnOptions.Enabled = true;
                            lblMessage.Text = "Payment amount is greater than order amount."; // Click the MORE button for options";
                            //btnOptions.Font.Bold = true;
                        }
                        else if (paymentandorderamountstatus == PaymentAmount.PAYMENTAMOUNT_GREATER_THAN_ORDERAMOUNT)
                        {
                            //btnOptions.Enabled = true;
                            lblMessage.Text = "Payment amount is less than order amount.";// Click the MORE button for options";
                            //btnOptions.Font.Bold = true;
                        }

                    }

                    else
                    {
                        lblMessage.Text = MessageAlert.PAYMENT_REFERENCE_NUMBER_NOT_EXIST + ". " + MessageAlert.PAYMENT_ORDER_FAILED;

                    }

                }
                else
                {
                    lblMessage.Text = MessageAlert.PAYMENT_REFERENCE_NUMBER_REQUIRED;
                }
            }
            else
            {
                lblMessage.Text = "Please check the box provided below to indicate that you have reviewed the details of your order " +
                                  "and authorize Bayan Pay to pay the seller indicated above on your behalf.";
            }
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {

        }

    }
}