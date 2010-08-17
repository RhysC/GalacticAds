<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.StoreContract>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    New Store Contract
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        </h2>
    <form action="<%= this.Url.RouteUrl(this.ViewContext.RouteData.Values) %>" method="post"
    enctype="multipart/form-data">
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>New Contract</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.StartDate) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.StartDate) %>
            <%: Html.ValidationMessageFor(model => model.StartDate) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.TermInMonths) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.TermInMonths)%>
            <%: Html.ValidationMessageFor(model => model.TermInMonths)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AgreedPricePerNonPrintedRoll) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.AgreedPricePerNonPrintedRoll) %>
            <%: Html.ValidationMessageFor(model => model.AgreedPricePerNonPrintedRoll) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AgreedPricePerPrintedRoll) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.AgreedPricePerPrintedRoll) %>
            <%: Html.ValidationMessageFor(model => model.AgreedPricePerPrintedRoll) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AgreedShippingRate) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.AgreedShippingRate) %>
            <%: Html.ValidationMessageFor(model => model.AgreedShippingRate) %>
        </div>
        <fieldset>
            <legend>Document</legend>
            <div class="editor-label">
                Contract Document
            </div>
            <div class="editor-field">
                <input type="file" name="FileUpload" />
            </div>
        </fieldset>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    </form>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#StartDate").datepicker();
        });
    </script>
</asp:Content>
