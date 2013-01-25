<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Navigation Builder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Navigation Builder</h1>
    
    <% if (Request.IsAuthenticated) { %>
        <p>Add navigation options</p>
    <% } else { %>
        <p>Please login to continue.</p>
    <% } %>
</asp:Content>
