using System;
using Microsoft.AspNet.Identity;
using Web.Actions;
using Web.ValueObjects;
using Web.Constants;


namespace SMSPaymentGateway.Main.Utils
{
    public partial class Success : System.Web.UI.Page
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
            lblUniqueTransactionCode.Text = Server.UrlDecode(Request.QueryString["utc"]);
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