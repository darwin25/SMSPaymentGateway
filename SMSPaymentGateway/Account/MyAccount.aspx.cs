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

namespace SMSPaymentGateway.Account
{
    public partial class MyAccount : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                this.GetProvinces();

                string friendlyname = Server.UrlDecode(Request.QueryString["customerid"]);
                if (string.IsNullOrEmpty(friendlyname))
                {
                    this.GetCustomerDetails();
                }
                else
                {
                    this.GetCustomerDetails();
                    txtFriendlyURLName.Text = friendlyname;

                    string friendlyurl = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/Order.aspx?payee=" + Encoder.UrlEncode(txtFriendlyURLName.Text);
                    lblFriendlyURL.Text = "<a href=" + friendlyurl + " title=" + friendlyurl + ">" + friendlyurl + "</a>";     
                }
                
            }
  
        }

        private void GetCustomerDetails()
        {
            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            AppFunctions af = new AppFunctions();
            DataSet ds = new DataSet();

            vo.EmailAddress1 = Context.User.Identity.GetUserName();
            //vo.FriendlyURLName = af.StripHTML(txtFriendlyURLName.Text);
            //vo.FirstName = af.StripHTML(txtFirstName.Text);
            //vo.MiddleName = af.StripHTML(txtMiddleName.Text);
            //vo.LastName = af.StripHTML(txtLastName.Text);
            //vo.MobileNumber = af.FormatMobileNumber(txtMobileNo.Text);
            //vo.Address = af.StripHTML(txtAddress.Text);
            //vo.Province = af.StripHTML(ddlProvince.Text);
            //vo.Town = af.StripHTML(ddlTown.Text);

            ds = doAction.GetCustomerDetails(vo);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFriendlyURLName.Text = af.DisplayText(ds.Tables[0].Rows[0]["customerfriendlyurlname"].ToString());
                string friendlyurl = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/Order.aspx?payee=" + Encoder.UrlEncode(txtFriendlyURLName.Text);            
                lblFriendlyURL.Text = "<a href=" + friendlyurl + " title=" + friendlyurl +">" +friendlyurl +"</a>" ;
                txtFirstName.Text = af.DisplayText(ds.Tables[0].Rows[0]["customerfirstname"].ToString());
                txtMiddleName.Text = af.DisplayText(ds.Tables[0].Rows[0]["customermiddlename"].ToString());
                txtLastName.Text = af.DisplayText(ds.Tables[0].Rows[0]["customerlastname"].ToString());
                txtMobileNo.Text = af.DisplayText(ds.Tables[0].Rows[0]["customermobilenumber"].ToString());
                txtAddress.Text = af.DisplayText(ds.Tables[0].Rows[0]["customeraddress"].ToString());
                ddlProvince.Text = af.DisplayText(ds.Tables[0].Rows[0]["customerprovince"].ToString());
                this.GetTowns(ddlProvince.Text);
                ddlTown.Text = af.DisplayText(ds.Tables[0].Rows[0]["customertown"].ToString());
            }

        }      

        protected void txtFriendlyURLName_TextChanged(object sender, EventArgs e)
        {

            UsersVO vo = new UsersVO();
            GetUserAction doAction = new GetUserAction();
            AppFunctions af = new AppFunctions();
            
            vo.FriendlyURLName = af.StripHTML(txtFriendlyURLName.Text);
        
            string result = doAction.CheckIfFriendlyNameExists(vo).ToString();

            if (result == "1")
            {
                string[] suggestednames = af.GetCompletionList(txtFriendlyURLName.Text, 4);
                int i;
                lblSuggested.Text = "Suggested Names:";
                lblFriendlyURLName.Text = "Friendly URL Name exists";
                for (i = 0; i < 4; i++)
                {
                    string friendlyname = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Account/MyAccount.aspx?customerid=" + Encoder.UrlEncode(suggestednames[i].ToString());
                    //lblSuggestedNames.Text = lblSuggestedNames.Text + "<a href=" + " title=" + suggestednames[i].ToString() + ">" + suggestednames[i].ToString() + "</br>"; 
                    lblSuggestedNames.Text = lblSuggestedNames.Text + "<a href=" + friendlyname + " title=" + friendlyname   + ">" + suggestednames[i].ToString() + "</br>"; 
                }
                
            }
            else
            {
                lblFriendlyURLName.Text = "";
                string friendlyurl = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/Main/Buy/Order.aspx?payee=" + Encoder.UrlEncode(txtFriendlyURLName.Text);
                lblFriendlyURL.Text = "<a href=" + friendlyurl + " title=" + friendlyurl + ">" + friendlyurl + "</a>";                
                lblSuggestedNames.Text = "";
                lblSuggested.Text = "";
                
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblFriendlyURLName.Text =="")
            {
                UsersVO vo = new UsersVO();
                GetUserAction doAction = new GetUserAction();
                AppFunctions af = new AppFunctions();

                vo.EmailAddress1 = Context.User.Identity.GetUserName();
                vo.FriendlyURLName = af.StripHTML(txtFriendlyURLName.Text);
                vo.FirstName = af.StripHTML(txtFirstName.Text);
                vo.MiddleName = af.StripHTML(txtMiddleName.Text);
                vo.LastName = af.StripHTML(txtLastName.Text);
                vo.MobileNumber = af.FormatMobileNumber(txtMobileNo.Text);
                vo.Address = af.StripHTML(txtAddress.Text);
                vo.Province = af.StripHTML(ddlProvince.Text);
                vo.Town = af.StripHTML(ddlTown.Text);

                string result = doAction.UpdateCustomerDetails(vo).ToString();

                if (result == ActionResult.ACTION_SUCCESSFUL)
                {
                    Message.Text = MessageAlert.RECORD_UPDATED;
                    Message.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    Message.Text = MessageAlert.RECORD_UPDATE_FAILED;
                }
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetTowns(ddlProvince.Text);
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
    }
}