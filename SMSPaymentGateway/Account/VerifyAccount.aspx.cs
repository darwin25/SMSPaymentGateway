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
    public partial class VerifyAccount : System.Web.UI.Page
    {

        //protected void Page_PreInit(object sender, System.EventArgs e)
        //{
        //    if ((Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1) | (Request.ServerVariables["http_user_agent"].IndexOf("Chrome", StringComparison.CurrentCultureIgnoreCase) != -1))
        //    {
        //        Page.ClientTarget = "uplevel";
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            this.VerifyEmailAddress();
            this.GetCustomerID();
        }

        private void GetCustomerID()
        {

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            string emailaddress;
            

            emailaddress = Email.Text;
            vo.EmailAddress1 = emailaddress;

            string customerid = doAction.GetCustomerID(vo).ToString();

            this.SendEmailCustomerURL(emailaddress, customerid);

        }

        private void VerifyEmailAddress() 
        { 
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.AuthenticationCode = Server.UrlDecode(Request.QueryString["verificationid"]);

            string result = doAction.CustomerConfirmEmailAddress(vo).ToString();

            if (result == "1")
            {
                Message.Text = MessageAlert.EMAIL_VERIFICATION_EXPIRED;
            }
            else
            {
                Email.Text = result;
                Message.Text = MessageAlert.EMAIL_VERIFIED + " You may now log into your account.";
                Message.ForeColor = System.Drawing.Color.Blue;
            }
        }

        private void SendEmailCustomerURL(string receipient, string customerid)
        {
            string sendfrom = ConfigurationManager.AppSettings["EMAIL_SENDFROM"].ToString();
            string password = ConfigurationManager.AppSettings["EMAIL_PASSWORD"].ToString();
            string smtphost = ConfigurationManager.AppSettings["EMAIL_SMTP_HOST"].ToString();
            string smtpport = ConfigurationManager.AppSettings["EMAIL_SMTP_PORT"].ToString();


            MailMessage mail = new MailMessage(sendfrom, receipient);
            mail.Subject = "Your email address has been verified";
            mail.Body = "Dear " + receipient +
                Environment.NewLine +
                Environment.NewLine +
                "Your email address has been verified. Belowe is you Orders URL." +
                Environment.NewLine +
                Environment.NewLine +
                Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/Order.aspx?payee=" +  Encoder.UrlEncode(customerid) +
                Environment.NewLine +
                Environment.NewLine +
                "Bayan Pay";
            //If fuAttachment.HasFile Then
            //    Dim FileName As String = Path.GetFileName(fuAttachment.PostedFile.FileName)
            //    mail.Attachments.Add(New Attachment(fuAttachment.PostedFile.InputStream, FileName))
            //End If
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtphost;
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(sendfrom, password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = Int32.Parse(smtpport);
            smtp.Send(mail);
       

        }
    }
}