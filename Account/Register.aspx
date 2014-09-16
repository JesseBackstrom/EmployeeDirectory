<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EmployeeDirectory.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    


    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="regErrorMessage" />
        <asp:Label runat="server" ID="lblError" />
    </p>
    <asp:panel  runat="server" ID ="pnlForm" Visible="true">
        <hgroup class="title">
        <h2>Use the form below to request a new account.</h2>
    </hgroup>
    <fieldset>
        <legend>Registration</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server">First Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFirstname" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server">Last Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server">Email</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server">Employee Id</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server"  ID="txtEmployeeId" MaxLength="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmployeeId" runat="server" ErrorMessage="Only Numbers Are Allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server">Role Requested</asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlRole"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server">Location</asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLocation"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSubmit" runat="server" OnClick="RegisterUser" Text="Submit"></asp:Button>
    </fieldset>
        </asp:panel>
    
    <asp:Panel runat="server" ID ="pnlMessage" Visible="false">
        <h2>Thank You For Registering!</h2>
        You will not be able to log in until you are approved by HR.
        <br />
        <asp:Button ID="login" runat="server" OnClick="Continue" Text="Continue"></asp:Button>
         
        </asp:Panel>
    

</asp:Content>


