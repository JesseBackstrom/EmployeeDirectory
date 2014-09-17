using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeDirectory.Business;

namespace EmployeeDirectory.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set Up Controls
            ListItem blank = new ListItem("", "0");

            ddlLocation.Items.Add(blank);
            ddlLocation.DataSource = PopulateFormService.getLocations();
            ddlLocation.DataValueField = "Value";
            ddlLocation.DataTextField = "Text";
            ddlLocation.AppendDataBoundItems = true;
            ddlLocation.DataBind();

            ddlRole.Items.Add(blank);
            ddlRole.DataSource = PopulateFormService.getRoles();
            ddlRole.DataValueField = "Value";
            ddlRole.DataTextField = "Text";
            ddlRole.AppendDataBoundItems = true;
            ddlRole.DataBind();

            if (User.IsInRole("HR"))
            {
            }
            else
            {
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            if (LoginService.isUniqueID(long.Parse(txtEmployeeId.Text)))
            {
                LoginService.updateUser(txtFirstname.Text, txtLastName.Text, long.Parse(txtEmployeeId.Text), int.Parse(ddlRole.SelectedValue), int.Parse(ddlLocation.SelectedValue), txtEmail.Text, 3);
                pnlForm.Visible = false;
                pnlMessage.Visible = true;

            }
            else
            {
                lblError.Text = "Sorry, that Employee ID is already taken.";
            }

        }
        protected void Continue(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}