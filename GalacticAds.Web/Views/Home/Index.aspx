<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %></h2>
    <p>
        We need to add some stuff to this site!
    </p>
    <p>
        Go to my <a href="http://webmail.galactads.com">web mail</a>
    </p>
</asp:Content>
