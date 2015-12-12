using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

namespace CommonFunctions
{
    public class AppFunctions
    {
        public AppFunctions()
        {
        }

        public String ParseString(string sVal, string startTag, string EndTag)
        {
            string sIn = sVal;
            string sOut = "";
            int tagStart = sIn.ToLower().IndexOf(startTag.ToLower());

            try
            {
                sIn = sIn.Remove(0, tagStart);
                sIn = sIn.Replace(startTag, "");
                int tagEnd = sIn.ToLower().IndexOf(EndTag.ToLower());

                string sName = sIn.Substring(0, tagEnd);

                sOut = sName;
            }
            catch
            {
            }
            return sOut;
        }

        public void disableCaching(HttpResponse response)
        {
            response.CacheControl = "no-cache";
            response.AddHeader("Pragma", "no-cache");
            response.Expires = -1;
        }

        public String GetProperName(string sIn)
        {
            if (sIn != null)
            {
                if (sIn.Length > 1)
                {
                    string propertyName = sIn;
                    string leftOne = propertyName.Substring(0, 1).ToUpper();
                    propertyName = propertyName.Substring(1, propertyName.Length - 1);
                    propertyName = leftOne + propertyName;
                    if (propertyName.EndsWith("TypeCode")) propertyName = propertyName.Substring(0, propertyName.Length - 4);
                    return propertyName;
                }
            }
            return sIn;
        }

        public String ParseCamelToProper(string sIn)
        {

            char[] letters = sIn.ToCharArray();
            string sOut = "";
            foreach (char c in letters)
            {
                if (c.ToString() != c.ToString().ToLower())
                {
                    //it's uppercase, add a space
                    sOut += " " + c.ToString();
                }
                else
                {
                    sOut += c.ToString();

                }
            }
            return sOut;
        }

        public Object StringToEnum(Type t, string Value)
        {
            object oOut = null;
            foreach (System.Reflection.FieldInfo fi in t.GetFields())
                if (fi.Name.ToLower() == Value.ToLower())
                    oOut = fi.GetValue(null);
            return oOut;
        }

        public String GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(1, false));
            builder.Append(RandomString(4, true));
            builder.Append(RandomInt(1000, 9999));
            builder.Append("_");
            builder.Append(RandomString(2, true));

            return builder.ToString();
        }
        private int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private String RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public String GetSiteRoot()
        {
            string Port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;

            string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";

            string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            if (appPath == "/")
                appPath = "";

            string sOut = Protocol + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + appPath;
            return sOut;
        }

        public String GetParameter(string sParam)
        {

            if (System.Web.HttpContext.Current.Request.QueryString[sParam] != null)
            {
                return System.Web.HttpContext.Current.Request[sParam].ToString();
            }
            else
            {
                return "";
            }

        }

        public int GetIntParameter(string sParam)
        {
            int iOut = 0;
            if (System.Web.HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string sOut = System.Web.HttpContext.Current.Request[sParam].ToString();
                if (!String.IsNullOrEmpty(sOut))
                    int.TryParse(sOut, out iOut);
            }
            return iOut;
        }

        public String GetFileText(string virtualPath)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(virtualPath));
            }
            catch
            {
                sr = new StreamReader(virtualPath);

            }
            string strOut = sr.ReadToEnd();
            sr.Close();
            return strOut;
        }

        public void UpdateFileText(string AbsoluteFilePath, string LookFor, string ReplaceWith)
        {
            string sIn = GetFileText(AbsoluteFilePath);
            string sOut = sIn.Replace(LookFor, ReplaceWith);
            WriteToFile(AbsoluteFilePath, sOut);
        }

        public void WriteToFile(string AbsoluteFilePath, string fileText)
        {
            StreamWriter sw = new StreamWriter(AbsoluteFilePath, false);
            sw.Write(fileText);
            sw.Close();

        }

        public void createMessageAlert(System.Web.UI.Page senderPage, string alertMsg, string alertKey)
        {
            string strScript = "<script language=JavaScript>alert('" + alertMsg + "')</script>";
            if ((!((senderPage.ClientScript.IsStartupScriptRegistered(alertKey)))))
            {
                senderPage.ClientScript.RegisterStartupScript(typeof(Page), alertKey, strScript);
            }
        }

        public double FormatNumberWithComma(string number)
        {
            return Convert.ToDouble(String.Format("{0:n2}", number));
        }

        public bool CheckIfNumeric(string strValue)
        {

            if (Information.IsNumeric(strValue) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string CheckStringLength(string stringToCheck, int maxLength)
        {
            string checkedString = null;

            if (stringToCheck.Length <= maxLength)
                return stringToCheck;

            // If the string to check is longer than maxLength 
            // and has no whitespace we need to trim it down.
            if ((stringToCheck.Length > maxLength) && (stringToCheck.IndexOf(" ") == -1))
            {
                checkedString = stringToCheck.Substring(0, maxLength) + "...";
            }
            else if (stringToCheck.Length > 0)
            {
                string[] words;
                int expectedWhitespace = stringToCheck.Length / 8;

                // How much whitespace is there?
                words = stringToCheck.Split(' ');

                checkedString = stringToCheck.Substring(0, maxLength) + "...";
            }
            else
            {
                checkedString = stringToCheck;
            }

            return checkedString;
        }

        public static string FormatDate(DateTime theDate)
        {
            return FormatDate(theDate, false, null);
        }

        public static string FormatDate(DateTime theDate, bool showTime)
        {
            return FormatDate(theDate, showTime, null);
        }

        public static string FormatDate(DateTime theDate, bool showTime, string pattern)
        {
            string defaultDatePattern = "MMMM d, yyyy";
            string defaultTimePattern = "hh:mm tt";

            if (pattern == null)
            {
                if (showTime)
                    pattern = defaultDatePattern + " " + defaultTimePattern;
                else
                    pattern = defaultDatePattern;
            }

            return theDate.ToString(pattern);
        }

        public static bool UserIsAuthenticated()
        {
            HttpContext context = HttpContext.Current;

            if (context.User != null &&
                context.User.Identity != null &&
                !String.IsNullOrEmpty(context.User.Identity.Name))
            {
                return true;
            }

            return false;
        }


        public string StripHTML(string htmlString)
        {
            return StripHTML(htmlString, "", true);
        }

        public static string StripHTML(string htmlString, string htmlPlaceHolder)
        {
            return StripHTML(htmlString, htmlPlaceHolder, true);
        }

        public static string StripHTML(string htmlString, string htmlPlaceHolder, bool stripExcessSpaces)
        {
            string pattern = @"<(.|\n)*?>";
            string sOut = System.Text.RegularExpressions.Regex.Replace(htmlString, pattern, htmlPlaceHolder);
            sOut = sOut.Replace("&nbsp;", "");
            sOut = sOut.Replace("&amp;", "&");

            if (stripExcessSpaces)
            {
                char[] delim = { ' ' };
                string[] lines = sOut.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                sOut = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (string s in lines)
                {
                    sb.Append(s);
                    sb.Append(" ");
                }
                return sb.ToString().Trim();
            }
            else
            {
                return sOut;
            }

        }

        public static string ToggleHtmlBR(string text, bool isOn)
        {
            string outS = "";

            if (isOn)
                outS = text.Replace("\n", "<br />");
            else
            {
                outS = text.Replace("<br />", "\n");
                outS = text.Replace("<br>", "\n");
                outS = text.Replace("<br >", "\n");
            }

            return outS;
        }

        public void clearFields(Control ParentCntl)
        {
            Control ctl = null;
            try
            {
                foreach (System.Web.UI.Control transTemp11 in ParentCntl.Controls)
                {
                    ctl = transTemp11;
                    if (ctl.GetType() == typeof(HtmlInputText))
                    {
                        HtmlInputText obj = ((HtmlInputText)(ctl));
                        obj.Value = "";
                    }
                    else if (ctl.GetType() == typeof(HtmlSelect))
                    {
                        HtmlSelect obj = ((HtmlSelect)(ctl));
                        obj.SelectedIndex = -1;
                    }
                    else if (ctl.GetType() == typeof(Label))
                    {
                        Label obj = ((Label)(ctl));
                        obj.Text = "";
                    }
                    else if (ctl.GetType() == typeof(TextBox))
                    {
                        TextBox obj = ((TextBox)(ctl));
                        obj.Text = "";
                    }
                    else if (ctl.GetType() == typeof(CheckBox))
                    {
                        CheckBox obj = ((CheckBox)(ctl));
                        obj.Checked = false;
                    }
                    else if (ctl.GetType() == typeof(RadioButton))
                    {
                        RadioButton obj = ((RadioButton)(ctl));
                        obj.Checked = false;
                    }
                    else if (ctl.GetType() == typeof(DropDownList))
                    {
                        DropDownList obj = ((DropDownList)(ctl));
                        obj.SelectedIndex = 0;
                    }

                    if (ctl.HasControls() == true)
                    {
                        clearFields(ctl);
                    }
                }

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public string Str2Fld(object varStrFld, bool blnIsAccess)
        {
            string str2FldReturn = null;

            string transTemp1 = varStrFld.ToString();
            string transTemp2 = varStrFld.ToString();
            if (System.Convert.IsDBNull(varStrFld))
            {
                str2FldReturn = System.DBNull.Value.ToString();
            }
            else if (transTemp1.Trim() == "")
            {
                str2FldReturn = System.DBNull.Value.ToString();
            }
            else if (transTemp2.Trim() == "&nbsp;")
            {
                str2FldReturn = System.DBNull.Value.ToString();
            }
            else
            {
                if (blnIsAccess == true)
                {
                    string transTemp3 = varStrFld.ToString();
                    string transTemp4 = "'";
                    string transTemp5 = "";
                    str2FldReturn = Strings.Replace(transTemp3, transTemp4, transTemp5, 1, -1, (Microsoft.VisualBasic.CompareMethod)(0));
                    str2FldReturn = (StripReplChar(System.Convert.ToString(varStrFld), System.Convert.ToString(System.Convert.ToChar(34)), "'")).Trim();
                }
                else
                {
                    str2FldReturn = (StripReplChar(System.Convert.ToString(varStrFld), "'", System.Convert.ToString(System.Convert.ToChar(34)))).Trim();
                }
            }

            return str2FldReturn;
        }

        public string StripReplChar(string stText, string stStripChar, string stReplChar)
        {
            string stripReplCharReturn = null;

            int iPos = 0;
            iPos = stText.IndexOf(stStripChar) + 1;
            if (iPos > 0)
            {
                while (!(iPos == 0))
                {
                    stText = Mid(System.Convert.ToString(1), iPos - 1, 0) + stReplChar + stText.Substring(System.Convert.ToInt32(double.Parse(stText)), iPos + 1);
                    iPos = stText.IndexOf(stStripChar) + 1;
                }
            }
            stripReplCharReturn = stText;

            return stripReplCharReturn;
        }

        public string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);

            return result;
        }

        public string Mid(string param, int startIndex)
        {
            string result = param.Substring(startIndex);

            return result;
        }

        public void SetFocus(object ClientID, Page Parent)
        {
            string strScript = null;

            strScript = "<SCRIPT language='javascript'>document.getElementById('" + ClientID + "').focus() </SCRIPT>";

            Parent.ClientScript.RegisterStartupScript(typeof(Page), "focus", strScript);
        }

        public object checkLoginIDnStatus(System.Web.UI.Page page, string sessionstatus)
        {

            if (!((Strings.UCase(sessionstatus)) == "AUTHORIZED"))
            {
                System.Web.UI.Page transTemp2 = page;
                transTemp2.Response.Redirect(transTemp2.Request.ApplicationPath + "../Default.aspx");

            }
            return null;
        }

        public void FillChkLookUp(Control ctl, string Param)
        {

            Web.Actions.ParameterAction pra = new Web.Actions.ParameterAction();
            DropDownList DropDown = ((DropDownList)(ctl));
            DataSet ds = new DataSet();

            try
            {
                DropDown.Items.Clear();

                ds = ((DataSet)(pra.handleRequest(Param)));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropDown.DataSource = ds.Tables[0];
                    DropDown.DataValueField = ds.Tables[0].Columns["Code"].ColumnName;
                    DropDown.DataTextField = ds.Tables[0].Columns["Description"].ColumnName;
                    DropDown.DataBind();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                ds = null;
            }

        }

        public string FormatMobileNumber(string mobilenumber)
        {
            int msisdnlength;
            string msisdn;

            msisdnlength = mobilenumber.Length;

            if (msisdnlength >= 10 && msisdnlength <= 13)
            {
                msisdn = "+63" + Strings.Right(Strings.Trim(mobilenumber), 10);

            }
            else
            {
                msisdn = mobilenumber;
            }
            return msisdn;

        }

        public string DisplayText(string strInput)
        {
            string result;
            if (Convert.IsDBNull(strInput.ToString()))
            {
                result = "";
            }
            else
            {
                result = strInput;
            }
            return result;
        }

        public string DisplayInt(string strInput)
        {
            string result;
            if (strInput == "0")
            {
                result = "";
            }
            else
            {
                result = strInput;
            }
            return result;
        }

        public string DisplayDate(string strInput)
        {
            string result;
            if (string.IsNullOrEmpty(strInput))
            {
                result = "";
            }
            else
            {
                result = Convert.ToDateTime(strInput).Date.ToString("yyyy-MM-dd");
            }
            return result;
        }

        public bool ValidateInput(string input, string inputType)
        {
            string pattern = null;
            bool result = false;

            switch (inputType)
            {
                case "1": //name
                    pattern = "^[a-zA-Z''-'\\s]{1,40}$";
                    break;
                case "2": //Philippine mobile number
                    pattern = "/(^0|[89]\\d{2}-\\d{3}\\-?\\d{4}$)|(^0|[89]\\d{2}\\d{3}\\d{4}$)|(^63[89]\\d{2}-\\d{3}-\\d{4}$)|(^63[89]\\d{2}\\d{3}\\d{4}$)|(^[+]63[89]\\d{2}\\d{3}\\d{4}$)|(^[+]63[89]\\d{2}-\\d{3}-\\d{4}$)/";
                    break;
                case "3": //email address                    
                    pattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))" + "(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
                    break;
                case "4": //address
                    pattern = "[0-9a-zA-Z #,-]+";
                    break;
                case "5": //amount
                    pattern = "^\\d+(\\.\\d\\d)?";
                    break;
                case "6": // password
                    pattern = "(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[_!@#$%])^([a-zA-Z0-9_!@#$%]{8,20})$";
                    break;
                case "10": //other
                    pattern = "^[0-9a-zA-Z #,-]+";
                    break;
            }

            if (Regex.IsMatch(input, pattern))
            {
                result = true;
            }

            return result;
        }

        public object IIf(bool Expression, object TruePart, object FalsePart)
        {
            object ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        public string IIf(bool Expression, string TruePart, string FalsePart)
        {
            string ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        public bool IIf(bool Expression, bool TruePart, bool FalsePart)
        {
            bool ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        public int IIf(bool Expression, int TruePart, int FalsePart)
        {
            int ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        public void detectBrowser(System.Web.UI.Page page, System.Web.HttpBrowserCapabilities browser)
        {

            System.Web.UI.Page transTemp2 = page;
            System.Web.HttpBrowserCapabilities browser2 = browser;

            if (browser2.Browser == "IE" && Convert.ToDecimal(browser2.Version) <= 8)

                transTemp2.Response.Redirect("~/NotSupported.aspx");

        }

        public string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public void SendEmail(string receipient, string subject, string body)
        {
            string sendfrom = ConfigurationManager.AppSettings["EMAIL_SENDFROM"].ToString();
            string password = ConfigurationManager.AppSettings["EMAIL_PASSWORD"].ToString();
            string smtphost = ConfigurationManager.AppSettings["EMAIL_SMTP_HOST"].ToString();
            string smtpport = ConfigurationManager.AppSettings["EMAIL_SMTP_PORT"].ToString();


            MailMessage mail = new MailMessage(sendfrom, receipient);
            mail.Subject = subject;
            mail.Body = body;
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

        public void SendEmailInHTML(string receipient, string subject, string body)
        {
            string sendfrom = ConfigurationManager.AppSettings["EMAIL_SENDFROM"].ToString();
            string password = ConfigurationManager.AppSettings["EMAIL_PASSWORD"].ToString();
            string smtphost = ConfigurationManager.AppSettings["EMAIL_SMTP_HOST"].ToString();
            string smtpport = ConfigurationManager.AppSettings["EMAIL_SMTP_PORT"].ToString();


            MailMessage mail = new MailMessage(sendfrom, receipient);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtphost;
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(sendfrom, password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = Int32.Parse(smtpport);
            smtp.Send(mail);

        }
        public string[] GetCompletionList(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }

            if (prefixText.Equals("xyz"))
            {
                return new string[0];
            }

            Random random = new Random();
            List<string> items = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                //char c1 = (char)random.Next(65, 90);
                //char c2 = (char)random.Next(97, 122);
                //char c3 = (char)random.Next(97, 122);
                int i1 = (char)random.Next(0, 9);
                int i2 = (char)random.Next(0, 9);
                int i3 = (char)random.Next(0, 9);
                int i4 = (char)random.Next(0, 9);
                items.Add(prefixText + i1 + i2 + i3 + i4);
            }

            return items.ToArray();
        }

    }
}
