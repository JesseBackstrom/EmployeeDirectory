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
        }
        protected void btnLogin(object sender, EventArgs e)
        {
            //use the service to authenticate
            User currentUser = LoginService.AuthenticateUser(long.Parse(txtEmployeeId.Text), Password.Text);

            if ((currentUser != null))
            {
                if (currentUser.Status.Equals("Password Required"))
                {
                    Session["User"] = currentUser;
                    Server.Transfer("~/Account/Password.aspx");
                }
                //check to see if the account is active
                if (currentUser.Status.Equals("Pending") | currentUser.Status.Equals("Inactive"))
                    FailureText.Text = "Your account is either pending, or inactive. Please contact HR.";

                if (currentUser.Status.Equals("Active"))
                {
                    //create and add the forms authentication ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, currentUser.FirstName, DateTime.Now, DateTime.Now.AddSeconds(1200), true, currentUser.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    // send to default page
                    

                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtEmployeeId.Text,false));
                }

                if (string.IsNullOrEmpty(currentUser.Status))
                {
                    FailureText.Text = "Invalid Credentials.";
                }

            }
            else
            {
                    FailureText.Text = "Invalid Credentials.";
                }
        }
    }
}