<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeDirectory.Account.Login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <h4>If your account is pending, you will be sent to another page to confirm your password.</h4>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtEmployeeId">Employee ID</asp:Label>
                            <asp:TextBox runat="server" ID="txtEmployeeId" TextMode="Number"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmployeeId" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="field-validation-error" ControlToValidate="txtEmployeeId" runat="server" ErrorMessage="Only Numbers Are Allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
               
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        </li>
                    </ol>
                    <asp:Button runat="server" Onclick="btnLogin" Text="Log in" />
                </fieldset>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>

</asp:Content>
