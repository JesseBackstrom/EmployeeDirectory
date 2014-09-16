<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.cs" Inherits="EmployeeDirectory.Error" %>




<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>The application has experienced an error.</h2>
            </hgroup>
            <p>
                <asp:Button ID="btnLink" OnClick="navigate" text="Return to Search Page." runat="server" />
            </p>
        </div>
    </section>
</asp:Content>