<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeDirectory._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Search for Employees here</h2>
            </hgroup>
            <p>
                here are simple instructions for use
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>This is where we will store the controls.</h3>
    <ol class="round">
        <li class="one">
            <h5>Here are some search controls.</h5>
        </li>
        <li class="two">
            <h5>Here is a grid.</h5>
        </li>
    </ol>
</asp:Content>
