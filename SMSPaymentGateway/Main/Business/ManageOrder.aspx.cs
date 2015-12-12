using System;
using System.Data;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;
using CommonFunctions;
using Microsoft.Security.Application;

namespace SMSPaymentGateway.Main.Business
{
    public partial class ManageOrder : System.Web.UI.Page
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
                this.GetDeliveryProviders();

                string uniquetransactioncode;
                uniquetransactioncode = Server.UrlDecode(Request.QueryString["utc"]);
                
                this.GetOrderDetails(uniquetransactioncode);
            }

        }

        protected void btnPayOrder_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == true)
            {
               
                OrdersVO vo = new OrdersVO();
                GetOrderAction doAction = new GetOrderAction();
                AppFunctions af = new AppFunctions();

                vo.UniqueTransactionCode = txtUniqueTransactionCode.Text;
                vo.DeliveryProvider = ddlSentThru.Text;
                vo.TrackingNumber = af.StripHTML(txtTrackingNumber.Text);
                vo.DateValue1 = Convert.ToDateTime(txtDateSentForDelivery.Text);
                vo.DateValue2 = Convert.ToDateTime(txtEstimatedDateOfDelivery.Text);

                string result = doAction.UpdateOrder(vo).ToString();

                if (result == ActionResult.ACTION_SUCCESSFUL)
                {
                    this.SendEmailConfirmationToBuyer(txtCustomerEmailAddress.Value, txtUniqueTransactionCode.Text,
                                                    txtOrderDescription.Text, ddlSentThru.Text, txtTrackingNumber.Text,
                                                    Convert.ToDateTime(txtDateSentForDelivery.Text),Convert.ToDateTime(txtEstimatedDateOfDelivery.Text));

                    lblMessage.Text = MessageAlert.RECORD_UPDATED;
                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Font.Size = 20;
                }
                else
                {
                    lblMessage.Text = MessageAlert.RECORD_UPDATE_FAILED;
                }
            }
               
        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        private void GetDeliveryProviders()
        {
            GetOrderAction doAction = new GetOrderAction();
            DataSet ds = new DataSet();

            ds = doAction.GetDeliveryProviders();

            ddlSentThru.Items.Add("");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.ddlSentThru.Items.Add(row["deliveryprovidername"].ToString());
            }

            ds.Dispose();


        }

        private void GetOrderDetails(string uniquetransactioncode)
        {
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();
            AppFunctions af = new AppFunctions();
            DataSet ds = new DataSet();

            vo.UniqueTransactionCode = uniquetransactioncode;
            ds = doAction.GetOrderDetails2(vo);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtOrderStatus.Text = af.DisplayText(ds.Tables[0].Rows[0]["orderstatus"].ToString()).ToUpper();
                txtCustomerID.Value = af.DisplayText(ds.Tables[0].Rows[0]["customerid"].ToString());                
                txtCustomerEmailAddress.Value = af.DisplayText(ds.Tables[0].Rows[0]["customeremailaddress"].ToString());
                txtsellerFriendlyURLName.Value = af.DisplayText(ds.Tables[0].Rows[0]["sellerfriendlyurlname"].ToString());
                txtSellerMobleNumber.Value = af.DisplayText(ds.Tables[0].Rows[0]["sellermobilenumber"].ToString());
                txtCustomerDetails.Text = af.DisplayText(ds.Tables[0].Rows[0]["customername"].ToString()) + "<br/>" +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customeraddress"].ToString()) + "<br/>" +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customertown"].ToString()) + ", " + af.DisplayText(ds.Tables[0].Rows[0]["customerprovince"].ToString()) + "<br/>" + //Environment.NewLine +
                                            af.FormatMobileNumber(ds.Tables[0].Rows[0]["customermobilenumber"].ToString()) + "<br/>" +
                                            af.DisplayText(ds.Tables[0].Rows[0]["customeremailaddress"].ToString());

                txtUniqueTransactionCode.Text = uniquetransactioncode;
                txtOrderDescription.Text = af.DisplayText(ds.Tables[0].Rows[0]["orderdescription"].ToString());
                txtOrderAmount.Text = "Php " + String.Format("{0:0,0.00}", Convert.ToDouble(ds.Tables[0].Rows[0]["orderamount"].ToString()));
                txtDateTimeCreated.Text = ds.Tables[0].Rows[0]["datetimecreated"].ToString();
                txtDateTimePOC.Text = ds.Tables[0].Rows[0]["datetimereceived"].ToString();
                lblDateTimePOC.Text = af.IIf(ds.Tables[0].Rows[0]["orderstatus"].ToString() == "Cancelled", "Date / Time Cancelled", "Date / Time Paid");
                txtPaymentReferenceNumber.Text = af.DisplayText(ds.Tables[0].Rows[0]["paymentreferencenumber"].ToString());
                ddlSentThru.Text = af.DisplayText(ds.Tables[0].Rows[0]["ordersentthru"].ToString());
                txtTrackingNumber.Text = af.DisplayText(ds.Tables[0].Rows[0]["ordertrackingnumber"].ToString());
                txtDateSentForDelivery.Text = af.DisplayDate(ds.Tables[0].Rows[0]["orderdatesent"].ToString());
                txtEstimatedDateOfDelivery.Text = af.DisplayDate(ds.Tables[0].Rows[0]["orderestimateddateofdelivery"].ToString());
               
            }
            else
            {
                lblMessage.Text = MessageAlert.NO_RECORD_FOUND;
            }

        }

        private bool ValidateInput()
        {
            bool functionReturnValue = false;
            AppFunctions af = new AppFunctions();

            if (string.IsNullOrEmpty(this.ddlSentThru.Text))
            {
                lblSentThruValidator.Text = MessageAlert.DELIVERY_PROVIDER_REQUIRED;
                return functionReturnValue;
            }
            else if(string.IsNullOrEmpty(this.txtTrackingNumber.Text))
            {
                lblTrackingNumberValidator.Text = MessageAlert.TRACKING_NUMBER_REQUIRED;
                functionReturnValue = false;
            }
            else if(string.IsNullOrEmpty(this.txtDateSentForDelivery.Text))
            {
                lblDateSentValidator.Text = MessageAlert.DATE_SENT_REQUIRED;
                functionReturnValue = false;
            }
            else if (string.IsNullOrEmpty(this.txtEstimatedDateOfDelivery.Text))
            {
                lblEstimatedDateOfDeliveryValidator.Text = MessageAlert.ESTIMATED_DATE_OF_DELIVERY_REQUIRED;
                functionReturnValue = false;
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        

        protected void ddlSentThru_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ddlSentThru.Text))
            {
                lblSentThruValidator.Text = MessageAlert.DELIVERY_PROVIDER_REQUIRED;
            }
            else
            {
                lblSentThruValidator.Text = "";
            }
        }

        protected void txtTrackingNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTrackingNumber.Text))
            {
                lblTrackingNumberValidator.Text = MessageAlert.TRACKING_NUMBER_REQUIRED;
            }
            else
            {
                lblTrackingNumberValidator.Text = "";
            }
        }

        protected void txtDateSentForDelivery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDateSentForDelivery.Text))
            {
                lblDateSentValidator.Text = MessageAlert.DATE_SENT_REQUIRED;
            }
            else
            {
                lblDateSentValidator.Text = "";
            }
        }

        protected void txtEstimatedDateOfDelivery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEstimatedDateOfDelivery.Text))
            {
                lblEstimatedDateOfDeliveryValidator.Text = MessageAlert.ESTIMATED_DATE_OF_DELIVERY_REQUIRED;
            }
            else
            {
                lblEstimatedDateOfDeliveryValidator.Text = "";
            }
        }

        private void SendEmailConfirmationToBuyer(string receipient, string uniquetransactioncode, string orderdescription,
                                                string deliveryprovider, string trackingnumber, DateTime datesent, DateTime estimateddateofdelivery)
        {
            AppFunctions af = new AppFunctions();

            string subject = "Your order is sent for delivery";
            string body = "Dear " + receipient +
                "<br/>" +                
                "<p>Your order has been shipped to</p>" +
                "<br/>" +
                "<p>    " + txtCustomerDetails.Text + " </p>" +
                "<br/>" +
                "<p>Seller: " + txtsellerFriendlyURLName.Value + " </p>" +
                "<p>Seller's  email address: " + Context.User.Identity.GetUserName() + " </p>" +
                "<p>Seller's  moblie number: " + txtSellerMobleNumber.Value + " </p>" +
                "<p>Unique Transaction Code: " + uniquetransactioncode + " </p>" +
                "<p>Order Description: " + orderdescription + " </p>" +
                "<p>Delivery Provider: " + deliveryprovider + " </p>" +
                "<p>Tracking Number: <b>" + trackingnumber + "</b></p>" +
                "<p>Date Sent for delivery: " + datesent.Date.ToString("MM-dd-yyyy") + " </p>" +
                "<p>Estimated date of delivery: " + estimateddateofdelivery.Date.ToString("MM-dd-yyyy") + " </p>" +
                "<p>You can always view the status of your order here: " + Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/MyOrder.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode) + " </p>" +
                "<br/>" +                
                "<p>Bayan Pay</p>";
            
            af.SendEmailInHTML(receipient, subject, body);
        }
    

    }
}