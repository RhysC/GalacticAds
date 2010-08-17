`<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Store>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: Model.Name %></h2>
    <fieldset>
        <legend>Address</legend>
        <div class="display-field">
            <%: Model.GeographicalLocation.ToString() %>
        </div>
        <span class="display-label">Latitude </span>
        <div class="display-field">
            <%: Model.GeographicalLocation.Latitude %>
        </div>
        <span class="display-label">Longitude </span>
        <div class="display-field">
            <%: Model.GeographicalLocation.Longitude %>
        </div>
    </fieldset>
    <fieldset>
        <legend>Roll Usage</legend>
        <% if (Model.RollUsageHistory.Count == 0)
           { %>
        No roll usage history is available
        <% }
           else
           {%>
        <table>
            <thead>
                <tr>
                    <th>
                        From
                    </th>
                    <th>
                        To
                    </th>
                    <th>
                        Usage
                    </th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var usage in Model.RollUsageHistory)
                   {  %>
                <tr>
                    <td>
                        <%: usage.Period.StartDate %>
                    </td>
                    <td>
                        <%: usage.Period.EndDate %>
                    </td>
                    <td>
                        <%: usage.NumberOfRollsUsed %>
                    </td>
                </tr>
                <% }%>
            </tbody>
        </table>
        <% } %>
    </fieldset>
    <fieldset>
        <legend>Current Contract</legend>
        <%  var contract = Model.GetCurrentContract();
            if (contract == null)
            { %>
        <div class="display-warning;display-label">There is no current contract for this
            store </div>
        <% }
            else
            {
        %>
        <span class="display-label">Start Date</span> <span class="display-field">
            <%: contract.StartDate %></span> <span class="display-label">End Date</span>
        <span class="display-field">
            <%: contract.EndDate %></span> <span class="display-label">Agreed Price Per Printed
                Roll</span>
        <div class="display-field">
            <%: contract.AgreedPricePerPrintedRoll %></div>
        <span class="display-label">Agreed Shipping Rate</span>
        <div class="display-field">
            <%: contract.AgreedShippingRate %></div>
        <%: Html.ActionLink("View Contract", "Details", "StoreContract", new { id = Model.Id, contractId = contract.Id })%>
        |
        <% } %>
        <%: Html.ActionLink("View All Contracts", "Index", "StoreContract", new { id = Model.Id })%>
        |
        <%: Html.ActionLink("Add New Contract", "Create", "StoreContract", new { id = Model.Id },null)%>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        |
        <%: Html.ActionLink("Map", "Map", new { id=Model.Id }) %>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
