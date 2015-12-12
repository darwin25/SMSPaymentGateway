using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Actions;
using Web.Constants;
using Web.ValueObjects;
using Microsoft.AspNet.Identity;

namespace SMSPaymentGateway.Main.Utils
{
    public partial class WithdrawFunds : System.Web.UI.Page
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
                    Response.Redirect("~/Main/Main2.aspx");
                }
            }

            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}