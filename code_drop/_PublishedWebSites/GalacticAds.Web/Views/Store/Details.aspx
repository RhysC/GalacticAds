<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Store>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Store</legend>
        <span class="display-label">
            Id</span>
        <div class="display-field">
            <%: Model.Id %></div>
        <span class="display-label">
            Name</span>
        <div class="display-field">
            <%: Model.Name %></div>
        <% Html.RenderPartial("AddressDetail"); %>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id  }) %>
        |
        <%: Html.ActionLink("Map", "Map", new { id=Model.Id  }) %>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
