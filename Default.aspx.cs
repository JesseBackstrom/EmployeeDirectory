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
            GridViewRow row = gvEmployee.Rows[e.RowIndex];
            
            LoginService.updateUser(((TextBox)(row.Cells[2].Controls[0])).Text,
                ((TextBox)(row.Cells[3].Controls[0])).Text,
                long.Parse((((TextBox)(row.Cells[4].Controls[0])).Text)),
                SearchService.getRoleID(((TextBox)(row.Cells[5].Controls[0])).Text),
                SearchService.getLocationID(((TextBox)(row.Cells[6].Controls[0])).Text),
                ((TextBox)(row.Cells[7].Controls[0])).Text,
                SearchService.getStatusID(((TextBox)(row.Cells[8].Controls[0])).Text));
            search();
        }
        public void gridBinding(object sender, GridViewRowEventArgs e)
        {
            if (!this.User.IsInRole("HR"))
            {
                e.Row.Cells[0].Visible = false;
            }
            
            if ((e.Row.RowType == DataControlRowType.DataRow) & (e.Row.RowState != DataControlRowState.Edit))
            {
                e.Row.Cells[5].Text = SearchService.getRole(Convert.ToInt32(e.Row.Cells[5].Text));
                e.Row.Cells[6].Text = SearchService.getLocation(Convert.ToInt32(e.Row.Cells[6].Text));
                e.Row.Cells[8].Text = SearchService.getStatus(Convert.ToInt32(e.Row.Cells[8].Text));
            }
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                ((TextBox)(e.Row.Cells[5].Controls[0])).Text = SearchService.getRole(Convert.ToInt32(((TextBox)(e.Row.Cells[5].Controls[0])).Text));
                ((TextBox)(e.Row.Cells[6].Controls[0])).Text = SearchService.getLocation(Convert.ToInt32(((TextBox)(e.Row.Cells[6].Controls[0])).Text));
                ((TextBox)(e.Row.Cells[8].Controls[0])).Text = SearchService.getStatus(Convert.ToInt32(((TextBox)(e.Row.Cells[8].Controls[0])).Text));
            }

        }
        protected void search()
        {
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
