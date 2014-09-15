<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EmployeeDirectory.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>Use the form below to create a new account.</h2>
    </hgroup>


    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
                <asp:Label runat="server" AssociatedControlID="UserName">First name</asp:Label>
                <asp:TextBox runat="server" ID="txtFirstName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="field-validation-error" ErrorMessage="The first name field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="UserName">Last name</asp:Label>
                <asp:TextBox runat="server" ID="txtLastName" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                    CssClass="field-validation-error" ErrorMessage="The last name field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
            </li>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="Email">Employee ID</asp:Label>
                <asp:TextBox runat="server" ID="txtEmpID" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                    CssClass="field-validation-error" ErrorMessage="The employee id field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="Email">Location</asp:Label>
                <asp:DropDownList runat="server" ID="ddlLocation" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Email"
                    CssClass="field-validation-error" ErrorMessage="The employee id field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="Email">Requested Role</asp:Label>
                <asp:DropDownList runat="server" ID="ddlRole" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Email"
                    CssClass="field-validation-error" ErrorMessage="The employee id field is required." />
            </li>
        </ol>
        <asp:Button runat="server" OnClick="RegisterUser" Text="Register" />
    </fieldset>
</asp:Content>
