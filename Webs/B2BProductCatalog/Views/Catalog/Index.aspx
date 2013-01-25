<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Catalog Management - Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Where would you like to go?</h1>
    
    <% if (Request.IsAuthenticated) { %>
        <p>Use the navigation along the top to begin.</p>
    <% } else { %>
        <p>
            Please <%= Html.ActionLink("sign in", "LogOn", "Account") %> or 
            <%= Html.ActionLink("register an account", "Register", "Account") %> to continue.
        </p>
    <% } %>
</asp:Content>
