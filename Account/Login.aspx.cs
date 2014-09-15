using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using EmployeeDirectory.Business;

namespace EmployeeDirectory.Account
{
    
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //RegisterHyperLink.NavigateUrl = "Register.aspx";

            /*var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
             */
        }
        protected void btnLogin(object sender, EventArgs e)
        {
            bool valid = LoginService.AuthenticateUser(Email.Text, Password.Text);
            if (valid)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(Email.Text, false, 10);
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                Response.Redirect(FormsAuthentication.GetRedirectUrl(Email.Text, false));
            }
        }
    }
}