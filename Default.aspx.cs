using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeDirectory.Business;

namespace EmployeeDirectory
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set up form
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

                ddlStatus.Items.Add(blank);
                ddlStatus.DataSource = PopulateFormService.getStatuses();
                ddlStatus.DataValueField = "Value";
                ddlStatus.DataTextField = "Text";
                ddlStatus.AppendDataBoundItems = true;
                ddlStatus.DataBind();
            }

            


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void rowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvEmployee.Rows[rowIndex];
        }

        public void rowEdit(object sender, GridViewEditEventArgs e)
        {
            gvEmployee.EditIndex = e.NewEditIndex;
            search();
        }

        public void rowEditCancel(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployee.EditIndex = -1;
            search();
        }
        public void rowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvEmployee.EditIndex = -1;

            GridViewRow row = gvEmployee.Rows[e.RowIndex];

            //update the user record
            LoginService.updateUser(((TextBox)(row.Cells[2].Controls[0])).Text,
                ((TextBox)(row.Cells[3].Controls[0])).Text,
                long.Parse(row.Cells[1].Text),
                Convert.ToInt32((row.FindControl("ddlTRole") as DropDownList).SelectedValue),
                Convert.ToInt32((row.FindControl("ddlTLocation") as DropDownList).SelectedValue),
                ((TextBox)(row.Cells[4].Controls[0])).Text,
                
                Convert.ToInt32((row.FindControl("ddlTStatus") as DropDownList).SelectedValue));
            search();
        }
        public void gridBinding(object sender, GridViewRowEventArgs e)
        {            

            if (!this.User.IsInRole("HR"))
            {
                //show the command buttons if the user is in HR
                e.Row.Cells[0].Visible = false;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) & !((e.Row.RowState & DataControlRowState.Edit) > 0))
            {
                // This is a regular non-edit data row, fill the drop down lists, but disable them
                DropDownList ddlTLocation = (e.Row.FindControl("ddlTLocation") as DropDownList);
                ddlTLocation.DataSource = PopulateFormService.getLocations();
                ddlTLocation.DataValueField = "Value";
                ddlTLocation.DataTextField = "Text";
                ddlTLocation.DataBind();
                Label lblLocation = (e.Row.FindControl("lblLocation") as Label);
                ddlTLocation.Items.FindByValue(lblLocation.Text).Selected = true;
                ddlTLocation.Enabled = false;

                DropDownList ddlTRole = (e.Row.FindControl("ddlTRole") as DropDownList);
                ddlTRole.DataSource = PopulateFormService.getRoles();
                ddlTRole.DataValueField = "Value";
                ddlTRole.DataTextField = "Text";
                ddlTRole.DataBind();
                Label lblRole = (e.Row.FindControl("lblRole") as Label);
                ddlTRole.Items.FindByValue(lblRole.Text).Selected = true;
                ddlTRole.Enabled = false;

                DropDownList ddlTStatus = (e.Row.FindControl("ddlTStatus") as DropDownList);
                ddlTStatus.DataSource = PopulateFormService.getStatuses();
                ddlTStatus.DataValueField = "Value";
                ddlTStatus.DataTextField = "Text";
                ddlTStatus.DataBind();
                Label lblStatus = (e.Row.FindControl("lblStatus") as Label);
                ddlTStatus.Items.FindByValue(lblStatus.Text).Selected = true;
                ddlTStatus.Enabled = false;

            }
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //This is an editable row, do some UI cleanup, fill the drop downs, and enable them

                ((TextBox)(e.Row.Cells[2].Controls[0])).Width = 100;
                ((TextBox)(e.Row.Cells[3].Controls[0])).Width = 100;
                ((TextBox)(e.Row.Cells[4].Controls[0])).Width = 100;               

                DropDownList ddlTLocation = (e.Row.FindControl("ddlTLocation") as DropDownList);
                ddlTLocation.DataSource = PopulateFormService.getLocations();
                ddlTLocation.DataValueField = "Value";
                ddlTLocation.DataTextField = "Text";
                ddlTLocation.DataBind();
                Label lblLocation = (e.Row.FindControl("lblLocation") as Label);
                ddlTLocation.Items.FindByValue(lblLocation.Text).Selected = true;
                ddlTLocation.Enabled = true;

                DropDownList ddlTRole = (e.Row.FindControl("ddlTRole") as DropDownList);
                ddlTRole.DataSource = PopulateFormService.getRoles();
                ddlTRole.DataValueField = "Value";
                ddlTRole.DataTextField = "Text";
                ddlTRole.DataBind();
                Label lblRole = (e.Row.FindControl("lblRole") as Label);
                ddlTRole.Items.FindByValue(lblRole.Text).Selected = true;
                ddlTRole.Enabled = true;

                DropDownList ddlTStatus = (e.Row.FindControl("ddlTStatus") as DropDownList);
                ddlTStatus.DataSource = PopulateFormService.getStatuses();
                ddlTStatus.DataValueField = "Value";
                ddlTStatus.DataTextField = "Text";
                ddlTStatus.DataBind();
                Label lblStatus = (e.Row.FindControl("lblStatus") as Label);
                ddlTStatus.Items.FindByValue(lblStatus.Text).Selected = true;
                ddlTStatus.Enabled = true;
            }

        }
        protected void search()
        {

            //gets data for the grid view

            long empID = 0;
            if (!string.IsNullOrEmpty(txtEmpId.Text))
                empID = long.Parse(txtEmpId.Text);
            gvEmployee.DataSource = SearchService.search
                (txtFirst.Text,
                txtLast.Text,
                txtEmail.Text,
                empID,
                int.Parse(ddlLocation.SelectedValue),
                int.Parse(ddlRole.SelectedValue),
                int.Parse(ddlStatus.SelectedValue)).Tables[0];
            gvEmployee.DataBind();
        }
        protected void indexChanged(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            search();
        }
    }
}
