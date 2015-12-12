using System;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Drawing;
using Microsoft.Security.Application;
using Web.ValueObjects;
using Web.Actions;
using Web.Constants;

namespace SMSPaymentGateway.Main.Utils
{
    public partial class WithdrawMethods : System.Web.UI.Page
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

        private string GetCustomerType(string emailaddress)
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();


            vo.EmailAddress1 = emailaddress;
            return doAction.GetCustomerType(vo).ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmailAddress.Value = Context.User.Identity.GetUserName();

                GridView1.DataBind();

                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                //GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSubmit);
                
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                int rIndex;
                string withdrawmethodid;

                rIndex = Convert.ToInt32(e.CommandArgument.ToString());

                withdrawmethodid = GridView1.DataKeys[rIndex].Value.ToString();

                Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Utils/WithdrawFunds.aspx?utc=" + Encoder.UrlEncode(withdrawmethodid));

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[5].Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Utils/AddWithdrawMethod.aspx");
        }
    }
}