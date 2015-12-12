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

namespace SMSPaymentGateway.Main.Buy
{
    public partial class Order : System.Web.UI.Page
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
                
               txtSellerCustomerID.Value = Server.UrlDecode(Request.QueryString[af.StripHTML("payee")]);
               this.GetSellerDetails(txtSellerCustomerID.Value);
               this.GetProvinces();
               txtPaymentAmount.Text = "0.00";
            }
        }

        protected void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();
            string emailaddress;

            if (af.ValidateInput(txtEmailAddress.Text, InputType.EMAIL_ADDRESS) == true)
            {
                emailaddress = txtEmailAddress.Text;
                this.GetCustomerDetails(emailaddress);
                lblEmailAddressValidator.Text ="" ;
            }
            else if (txtEmailAddress.Text == "")
            {
                lblEmailAddressValidator.Text = MessageAlert.EMAIL_ADDRESS_REQUIRED;

            }
            else
            {
                lblEmailAddressValidator.Text = MessageAlert.EMAIL_INVALID;
            }


        }

        protected void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();

            if (txtPaymentAmount.Text == "")
            {
                txtPaymentAmount.Text = "0.00";
                lblPaymentAmountValidator.Text = MessageAlert.PAYMENT_AMOUNT_REQUIRED;
            }
            else {

                double num;
                if (double.TryParse(txtPaymentAmount.Text, out num) == true && Convert.ToDouble(txtPaymentAmount.Text) > 0)
                {
                    txtPaymentAmount.Text = string.Format("{0:n2}", Convert.ToDecimal(txtPaymentAmount.Text));
                }
            
            }
      
        }

        protected void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                lblFirstNameValidator.Text = MessageAlert.FIRST_NAME_REQUIRED;
            }
            else
            {
                lblFirstNameValidator.Text = "";
            }
        }

        protected void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                lblLastNameValidator.Text = MessageAlert.LAST_NAME_REQUIRED;
            }
            else
            {
                lblLastNameValidator.Text = "";
            }

        }

        protected void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                lblAddressValidator.Text = MessageAlert.ADDRESS_REQUIRED;
            }
            else
            {
                lblAddressValidator.Text = "";
            }

        }

        protected void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMobileNo.Text == "")
            {
                lblMobileNumberValidator.Text = MessageAlert.MOBILE_NUMBER_REQUIRED;
            }
            else
            {
                lblMobileNumberValidator.Text = "";
            }
        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text == "")
            {
                lblDescriptionValidator.Text = MessageAlert.PAYMENT_DESCRIPTION_REQUIRED;
            }
            else
            {
                lblDescriptionValidator.Text = "";
            }
        }

        protected void ddlProvince_TextChanged(object sender, EventArgs e)
        {

            this.GetTowns(ddlProvince.Text);
      
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            

            if (ValidateInput() == true)
            {

                if (this.CheckBox1.Checked == true)
                {
                    AppFunctions af = new AppFunctions();
                    OrdersVO vo = new OrdersVO();
                    GetOrderAction doAction = new GetOrderAction();

                    // Dim sellercustomerid As String = Server.UrlDecode(Server.UrlDecode(Request.QueryString("payee")))

                    vo.FriendlyURLName = af.Str2Fld(this.txtSellerCustomerID.Value, true);
                    vo.EmailAddress2 = af.Str2Fld(this.txtEmailAddress.Text, true);
                    vo.FirstName = af.Str2Fld(this.txtFirstName.Text, true);
                    vo.MiddleName = af.Str2Fld(this.txtMiddleName.Text, true);
                    vo.LastName = af.Str2Fld(this.txtLastName.Text, true);
                    vo.Address = af.Str2Fld(this.txtAddress.Text, true);
                    vo.MobileNumber = af.FormatMobileNumber(this.txtMobileNo.Text);
                    vo.Province = af.Str2Fld(this.ddlProvince.Text, true);
                    vo.Town = af.Str2Fld(this.ddlTown.Text, true);
                    vo.OrderAmount = Convert.ToDouble(this.txtPaymentAmount.Text);
                    vo.OrderDescription = af.Str2Fld(this.txtDescription.Text, true);

                    string uniquetransactioncode = doAction.CreateOrder2(vo).ToString();

                    string password = af.GetRandomString();
                    RegisterUser(vo.EmailAddress2, password);

                    this.SendOrderToBuyerViaEmail(vo.EmailAddress2, uniquetransactioncode);
                    this.SendOrderToSellerViaEmail(txtSellerEmailAddress.Value, uniquetransactioncode);

                    Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority).ToString() +  "/Main/Buy/Success.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode));
                }
                else
                {
                    this.lblMessage.Text = MessageAlert.TNC_NOT_ACCEPTED;
                }
            }


        }

        private void RegisterUser(string emailaddress, string password)
        {
            if (this.CheckIfUserExists(emailaddress) != txtEmailAddress.Text)
            {

            
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = emailaddress, Email = emailaddress };
                IdentityResult result = manager.Create(user, password);
                if (result.Succeeded) 

                { 
                    UsersVO vo = new UsersVO();
                    GetUserAction doAction = new GetUserAction();

                    vo.EmailAddress1 = emailaddress;

                    string verificationcode = doAction.CreateVerificationCode(vo).ToString();

                    this.SendVerificationEmail(emailaddress, verificationcode, emailaddress, password);
                }

                       
            }

        }
        private void GetCustomerDetails(string emailaddress)
        {
            AppFunctions af = new AppFunctions();
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            DataSet ds = new DataSet();
           
            vo.EmailAddress1 = emailaddress;
            ds = doAction.GetCustomerDetails(vo);

           if (ds.Tables[0].Rows.Count > 0)
           {
                this.txtFirstName.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customerfirstname"].ToString(),true);
                this.txtMiddleName.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customermiddlename"].ToString(), true);
                this.txtLastName.Text =  af.Str2Fld(ds.Tables[0].Rows[0]["customerlastname"].ToString(),true);
                this.txtAddress.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customeraddress"].ToString(),true);
                this.txtMobileNo.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customermobilenumber"].ToString(),true);
                this.ddlProvince.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customerprovince"].ToString(),true);
                this.GetTowns(ddlProvince.Text);
                this.ddlTown.Text = af.Str2Fld(ds.Tables[0].Rows[0]["customertown"].ToString(), true);
           }
        }

        private void GetSellerDetails(string friendlyurlname)
        {
            AppFunctions af = new AppFunctions();
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            DataSet ds = new DataSet();

            vo.FriendlyURLName = friendlyurlname;

            ds = doAction.GetSellerDetails(vo);

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtSellerEmailAddress.Value = af.DisplayText(ds.Tables[0].Rows[0]["selleremailaddress"].ToString());

                txtPayee.Text = af.DisplayText(ds.Tables[0].Rows[0]["sellername"].ToString()) + "<br/>" + //Environment.NewLine +
                                                "<b><font size = " + 5 + ">" + af.DisplayText( ds.Tables[0].Rows[0]["sellerfriendlyurlname"].ToString()) + "</font></b><br/>" +
                                                 // af.DisplayText(ds.Tables[0].Rows[0]["selleremailaddress"].ToString()) + "<br/>" + // Environment.NewLine +
                                                  "Bayan Pay ID: <b>" + af.DisplayText(ds.Tables[0].Rows[0]["customerid"].ToString()) + "</b><br/>" + // Environment.NewLine +
                                                  af.FormatMobileNumber(ds.Tables[0].Rows[0]["sellermobilenumber"].ToString());
            }

        }

        private void GetProvinces()
        {

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            AppFunctions af = new AppFunctions();
            DataSet ds = new DataSet();

            ds = doAction.GetProvince();


            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.ddlProvince.Items.Add(row["province"].ToString());
            }
      

        }

        private void GetTowns(string province)
        {
            ddlTown.Items.Clear();

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            AppFunctions af = new AppFunctions();
            DataSet ds = new DataSet();


            vo.Province = province;

            ds = doAction.GetTown(vo);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.ddlTown.Items.Add(row["town"].ToString());
            }
        }

        public string CheckIfUserExists(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();

            vo.EmailAddress1 = emailaddress;

            return doAction.CheckIfUserExists(vo).ToString();
        }

        public string UpdateCustomerDetails(string payeecustomerid, string emailaddress, string firstname, 
                                string middlename, string lastname, string address, 
                                string mobileno, string province, string town)
        {

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();

            vo.FirstName = firstname;
            vo.MiddleName = middlename;
            vo.LastName = lastname;
            vo.Address = address;
            vo.MobileNumber = mobileno;
            vo.Province = province;
            vo.Town = town;

            return doAction.UpdateCustomerDetails(vo).ToString();
        }


        private string SaveOrder(string payeecustomerid, string emailaddress, string firstname, 
                                string middlename, string lastname, string address, 
                                string mobileno, string province, string town, 
                                double paymentamount, string paymentdescription)
        {


            AppFunctions af = new AppFunctions();
            OrdersVO vo = new OrdersVO();
            GetOrderAction doAction = new GetOrderAction();


            vo.SellerCustomerID = payeecustomerid;
            vo.EmailAddress2 = emailaddress;
            vo.FirstName = firstname;
            vo.MiddleName = middlename;
            vo.LastName = lastname;
            vo.Address = address;
            vo.MobileNumber = mobileno;
            vo.Province = province;
            vo.Town = town;
            vo.OrderAmount = paymentamount;
            vo.OrderDescription = paymentdescription;

            string result = doAction.CreateOrder2(vo).ToString();

            return result;

        }



        private bool ValidateInput()
        {
            bool functionReturnValue = false;
            AppFunctions af = new AppFunctions();

            if (string.IsNullOrEmpty(this.txtEmailAddress.Text))
            {
                this.lblEmailAddressValidator.Text = MessageAlert.EMAIL_ADDRESS_REQUIRED;

                return functionReturnValue;
            }
            else if (!af.ValidateInput(this.txtEmailAddress.Text,InputType.EMAIL_ADDRESS))
            {
                this.lblEmailAddressValidator.Text = MessageAlert.EMAIL_INVALID;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtFirstName.Text))
            {
                this.lblFirstNameValidator.Text = MessageAlert.FIRST_NAME_REQUIRED;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtLastName.Text))
            {
                this.lblLastNameValidator.Text = MessageAlert.LAST_NAME_REQUIRED;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.lblAddressValidator.Text = MessageAlert.ADDRESS_REQUIRED;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtMobileNo.Text))
            {
                this.lblMobileNumberValidator.Text = MessageAlert.MOBILE_NUMBER_REQUIRED;

                return functionReturnValue;

            }
            else if (!af.ValidateInput(this.txtMobileNo.Text, InputType.MOBILE_NUMBER))
            {
                this.lblMobileNumberValidator.Text = MessageAlert.MOBILE_INVALID;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtPaymentAmount.Text))
            {
                this.txtPaymentAmount.Text = "0.00";
                this.lblPaymentAmountValidator.Text = MessageAlert.PAYMENT_AMOUNT_REQUIRED;

                return functionReturnValue;

            }
            else if (string.IsNullOrEmpty(this.txtDescription.Text))
            {
                this.lblDescriptionValidator.Text = MessageAlert.PAYMENT_DESCRIPTION_REQUIRED;

                return functionReturnValue;

            }
            else
            {
                functionReturnValue = true;
            }

            return functionReturnValue;

        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        private void SendOrderToBuyerViaEmail(string receipient,  string uniquetransactioncode)
        {
            AppFunctions af = new AppFunctions();

            string subject = "Your Bayan Pay Transaction";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Click the link below to pay your order." +
                Environment.NewLine +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/MyOrder.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);

            
        }

        private void SendOrderToSellerViaEmail(string receipient, string uniquetransactioncode)
        {
            AppFunctions af = new AppFunctions();

            string subject = "You have an order";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Click the link below to review the details of the order." +
                Environment.NewLine +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/MyOrder.aspx?utc=" + Encoder.UrlEncode(uniquetransactioncode) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);

        }

        private void SendVerificationEmail(string receipient, string verificationid, string username, string password)
        {
           
            AppFunctions af = new AppFunctions();

            string subject = "Your Bayan Pay Account";
            string body =  "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Welcome to Bayan Pay. Click the link below to verify your email address" +
                Environment.NewLine +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Account/VerifyAccount.aspx?verificationid=" + Encoder.UrlEncode(verificationid) +
                Environment.NewLine +
                Environment.NewLine +
                "Your login credentials:" +
                Environment.NewLine +
                Environment.NewLine +
                "Username: " + username +
                Environment.NewLine +
                "Password: " + password +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";
            
            af.SendEmail(receipient, subject, body);
     
        }



    }
}