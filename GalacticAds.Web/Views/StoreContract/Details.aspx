<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.StoreContract>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: Model.Store.Name %></h2>
    <fieldset>
        <legend>Contract</legend>
        <div class="display-label">
            Start Date</div>
        <div class="display-field">
            <%: String.Format("{0:g}", Model.StartDate) %></div>
        <div class="display-label">
            End Date</div>
        <div class="display-field">
            <%: Model.EndDate %></div>
        <div class="display-label">
            Agreed Price Per Non Printed Roll</div>
        <div class="display-field">
            <%: String.Format("{0:F}", Model.AgreedPricePerNonPrintedRoll) %></div>
        <div class="display-label">
            Agreed Price Per Printed Roll</div>
        <div class="display-field">
            <%: String.Format("{0:F}", Model.AgreedPricePerPrintedRoll) %></div>
        <div class="display-label">
            Agreed Shipping Rate</div>
        <div class="display-field">
            <%: String.Format("{0:F}", Model.AgreedShippingRate) %></div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id = Model.Store.Id, contractId = Model.Id })%>
        |
         <%: Html.ActionLink("All Store Contracts", "index", "StoreContract", new { id = Model.Store.Id })%>
         |
        <%: Html.ActionLink("Store Details", "Detail", "Store", new { id = Model.Store.Id })%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
