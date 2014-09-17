using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeDirectory
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = (string)Session["error"];
        }
        protected void navigate(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}