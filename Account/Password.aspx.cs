using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using EmployeeDirectory.Business;

namespace EmployeeDirectory.Account
{
    public partial class Password : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreatePassword(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];
            LoginService.UpdatePassword(txtPassword.Text, currentUser.Employee_Id);
            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }

        protected void Continue(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}