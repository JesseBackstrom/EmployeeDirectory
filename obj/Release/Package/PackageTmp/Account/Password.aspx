<%@ Page Title="Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="EmployeeDirectory.Account.Password" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
    </hgroup>


    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="pwErrorMessage" />
    </p>
    <asp:Panel ID="pnlForm" runat="server" Visible="true">
        
        <h2>Thank you for Registering! Use the form below to create a Password.</h2>
        <fieldset>
            <legend>Password Form</legend>
            <ol>
                <li>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                        CssClass="field-validation-error" ErrorMessage="The password field is required." />
                </li>
                <li>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtConfirmPassword">Confirm password</asp:Label>
                    <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmPassword"
                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </li>
            </ol>
            <asp:Button runat="server" OnClick="CreatePassword" Text="Create Password" />
        </fieldset>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMessage" Visible="false">
        <h2>Thank You For Registering!</h2>
        You are now able to log in with your new password.
        <br />
        <asp:Button ID="login" runat="server" OnClick="Continue" Text="Continue"></asp:Button>

    </asp:Panel>
</asp:Content>
