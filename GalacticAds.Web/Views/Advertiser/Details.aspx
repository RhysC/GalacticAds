<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Advertiser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Store</legend>
        <div class="display-field">
            <span class="display-label">Id</span>
            <%: Model.Id %></div>
        <div class="display-field">
            <span class="display-label">Name</span>
            <%: Model.Name %></div>
        <div class="display-field">
            <span class="display-label">Categories</span>
            <%:string.Join(", ", Model.Categories.Select(x=>x.Name)) %></div>
        <% Html.RenderPartial("AddressDetail"); %>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id  }) %>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
