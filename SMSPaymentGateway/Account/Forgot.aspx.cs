using System;
using System.Web;
using System.Web.UI;
using CommonFunctions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SMSPaymentGateway.Models;

namespace SMSPaymentGateway.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "The user either does not exist or is not confirmed.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                this.SendResetPasswordLink(Email.Text, callbackUrl);
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }

        private void SendResetPasswordLink(string receipient, string callbackUrl)
        {


            AppFunctions af = new AppFunctions();

            string subject = "Reset your password";
            string body = "Dear " + receipient +
                "<p></p>" + //Environment.NewLine +
                "<p></p>" + //Environment.NewLine +    
                "<p></p>" + //Environment.NewLine +
                "<p></p>" + //Environment.NewLine +
                "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>." +
               // Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Account/VerifyAccount.aspx?verificationid=" + Encoder.UrlEncode(verificationid) +
                "<p></p>" + //Environment.NewLine +
                "<p></p>" + //Environment.NewLine +
                "Bayan Pay";

            af.SendEmailInHTML(receipient, subject, body);


        }
    }
}