<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Advertiser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create New Store</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Store</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
         <div class="editor-label">
            <%: Html.LabelFor(model => model.Categories) %>
        </div>
        <div class="editor-field">
            <%: Html.ListBoxFor(model => model.Categories, new SelectList(GalacticAds.Web.Models.Category.FindAll(), "Id", "Name"))%>
            <%: Html.ValidationMessageFor(model => model.Categories)%>
        </div>

        <% Html.RenderPartial("AddressEdit"); %>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
