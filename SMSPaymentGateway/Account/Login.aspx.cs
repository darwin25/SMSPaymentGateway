using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using SMSPaymentGateway.Models;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;


namespace SMSPaymentGateway.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                             
                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                UsersVO vo = new UsersVO();
                GetUserAction doAction = new GetUserAction();

                vo.EmailAddress1 = Email.Text;

                string isemailconfirmed = doAction.IsEmailConfirmed(vo).ToString();
                if (isemailconfirmed == "1")
                {
                    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                    switch (result)
                    {
                        case SignInStatus.Success:
                            //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                            string customer_type = this.GetCustomerType(Email.Text);

                            if (customer_type == CustomerType.BUSINESS)                             
                            {
                                IdentityHelper.RedirectToReturnUrl("~/Main/Main.aspx", Response);
                            }
                            else if (customer_type == CustomerType.INDIVIDUAL)
                            {
                                IdentityHelper.RedirectToReturnUrl("~/Main/Main2.aspx", Response);
                            }                            
                            break;
                        case SignInStatus.LockedOut:
                            Response.Redirect("/Account/Lockout");
                            break;
                        case SignInStatus.RequiresVerification:
                            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                            Request.QueryString["ReturnUrl"],
                                                            RememberMe.Checked),
                                              true);
                            break;
                        case SignInStatus.Failure:
                        default:
                            FailureText.Text = "Invalid login attempt";
                            ErrorMessage.Visible = true;
                            break;
                    }
                }

                else
                {
                    FailureText.Text = "You have not yet verified your account."; 
                    ErrorMessage.Visible = true;
                    
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
    }
}