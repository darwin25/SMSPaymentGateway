using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPaymentGateway
{
    public partial class NotSupported : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            string s = "You are using\n"

                + browser.Browser + " Version " + browser.Version;

            //string s = "You are using\n"
            //    + "Type = " + browser.Type + "<br/>"
            //    + "Name = " + browser.Browser + "<br/>"
            //    + "Version = " + browser.Version + "<br/>"
            //    + "Major Version = " + browser.MajorVersion + "<br/>"
            //    + "Minor Version = " + browser.MinorVersion + "<br/>"
            //    + "Platform = " + browser.Platform + "<br/>"
            //    + "Is Beta = " + browser.Beta + "<br/>"
            //    + "Is Crawler = " + browser.Crawler + "<br/>"
            //    + "Is AOL = " + browser.AOL + "<br/>"
            //    + "Is Win16 = " + browser.Win16 + "<br/>"
            //    + "Is Win32 = " + browser.Win32 + "<br/>"
            //    + "Supports Frames = " + browser.Frames + "<br/>"
            //    + "Supports Tables = " + browser.Tables + "<br/>"
            //    + "Supports Cookies = " + browser.Cookies + "<br/>"
            //    + "Supports VBScript = " + browser.VBScript + "<br/>"
            //    + "Supports JavaScript = " +
            //        browser.EcmaScriptVersion.ToString() + "<br/>"
            //    + "Supports Java Applets = " + browser.JavaApplets + "<br/>"
            //    + "Supports ActiveX Controls = " + browser.ActiveXControls
            //          + "<br/>";
            lblMessage.Text = s;
            lblMessage2.Text = "If you wish to continue using Internet Explorer, you should upgrade to " + "<a href= http://windows.microsoft.com/en-US/internet-explorer/download-ie/>IE 10 or higher.</a>" + "<br/>"  +
                                "But really...Do yourself a favor. This website is best viewed using modern browsers like " + "<br/>" +                                
                                "<a href= http://www.opera.com/>Opera</a>" + "<br/>" +
                                "<a href= https://www.mozilla.org/en-US/firefox/new/> Mozilla Firefox</a>" + "<br/>" +
                                "<a href= https://www.google.com/chrome/> Google Chrome</a>" + "<br/>" +
                                "<a href= http://www.maxthon.com/> Maxthon</a>" + "<br/>" +
                                "<a href= http://www.apple.com/safari/>Safari</a>";

            Session.Clear();

        }
    }
}