using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SMSPaymentGateway.Models;
using System.Net;
using System.Net.Mail;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;
using CommonFunctions;
using System.Configuration;
using Microsoft.Security.Application;


namespace SMSPaymentGateway.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            AppFunctions af = new AppFunctions();
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            af.detectBrowser(this.Page, browser);
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            AppFunctions af = new AppFunctions();
            
            if(ValidateInput() == true)
                { 

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
              
                var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
                IdentityResult result = manager.Create(user, Password.Text);
                
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);

                    
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");                    
                    //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);                   

                    string email =   Encoder.HtmlEncode(Email.Text);
                    string fnresult = CreateCustomer(email);

                    if (Email.Text.Substring(Email.Text.Length - 11) == "hotmail.com")
                    {
                        this.SendVerificationEmailToHotmail(Email.Text, fnresult);
                    }
                    else
                    {
                        this.SendVerificationEmail(Email.Text, fnresult);
                    }
                    
                    Message.Text = MessageAlert.REGISTRATION_SUCCESSFUL + MessageAlert.EMAIL_VERIFICATION_SENT + Email.Text.ToString();
                    Message.ForeColor = System.Drawing.Color.Blue;
                }
                else 
                {
                    Message.Text = result.Errors.FirstOrDefault();
                }
            }
        }


        private bool ValidateInput()
        {
            AppFunctions af = new AppFunctions();

        
            if (af.ValidateInput(Email.Text,InputType.EMAIL_ADDRESS) == false)
            {
                Message.Text = MessageAlert.EMAIL_INVALID;
                return false;
            }
            else if (af.ValidateInput(Password.Text,InputType.PASSWORD) == false)
            {
                Message.Text = MessageAlert.PASSWORD_INVALID;
                return false;
            }
            
            return true;
        }

        private string CreateCustomer(string email)
        {
            GetUserAction doAction = new GetUserAction();
            UsersVO vo = new UsersVO();
            AppFunctions af = new AppFunctions();
            //Dim af As New AppFunctions

            vo.EmailAddress1 = af.Str2Fld(email,true);

            string result = doAction.CreateCustomer(vo).ToString();

            return result;
            
        }

        private void SendVerificationEmail(string receipient,  string verificationid)
        {
            string callbackurl = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Account/VerifyAccount.aspx?verificationid=" + Encoder.UrlEncode(verificationid);

            AppFunctions af = new AppFunctions();

            string subject = "Verify your email address";
            string body = "Dear " + receipient +
                "<p></p>" + //Environment.NewLine +
                "<p></p>" + //Environment.NewLine +                    
                "Please verify your account by clicking <a href=\"" + callbackurl + "\">here</a>." +                                
                "<p></p>" + //Environment.NewLine +
                "<p></p>" + //Environment.NewLine +
                "Bayan Pay";

            af.SendEmailInHTML(receipient, subject, body);


        }

        private void SendVerificationEmailToHotmail(string receipient, string verificationid)
        {
            string callbackurl = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Account/VerifyAccount.aspx?verificationid=" + Encoder.UrlEncode(verificationid);

            AppFunctions af = new AppFunctions();

            string subject = "Verify your email address";
            string body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +                    
                "Please verify your account by clicking below: " +
                Environment.NewLine +
                Environment.NewLine +
                callbackurl +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";

            af.SendEmail(receipient, subject, body);


        }

    }
}