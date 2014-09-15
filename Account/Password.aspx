<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="EmployeeDirectory.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>Use the form below to create a Password.</h2>
    </hgroup>


    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="pwErrorMessage" />
    </p>

    <fieldset>
        <legend>Password Form</legend>
        <ol>
            <li>
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </li>
        </ol>
        <asp:Button runat="server" OnClick="RegisterUser" Text="Register" />
    </fieldset>
</asp:Content>
