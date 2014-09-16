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
            //use the service to authenticate
            User currentUser = LoginService.AuthenticateUser(long.Parse(txtEmployeeId.Text), Password.Text);

            if ((currentUser != null)& (currentUser.Status.Equals("Active")))
            {
                //check to see if the account is active
                if (currentUser.Status.Equals("Pending") | currentUser.Status.Equals("Inactive"))
                    FailureText.Text = "Your account is either pending, or inactive. Please contact HR.";

                else
                {
                    //create and add the forms authentication ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, currentUser.FirstName, DateTime.Now, DateTime.Now.AddSeconds(Session.Timeout), false, currentUser.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    // send to default page

                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtEmployeeId.Text, false));
                }
            }
            else
            {
                    FailureText.Text = "Invalid Credentials.";
            }
        }
    }
}