<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GalacticAds.Web.Models.Store>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
                Location
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.GeographicalLocation.ToString() %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.Id  }) %>
                |
                <%: Html.ActionLink("Details", "Details", new {  id=item.Id  })%>
                |
                <%: Html.ActionLink("Map", "Map", new {  id=item.Id  })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new {  id=item.Id  })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
