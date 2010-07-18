<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GalacticAds.Web.Models.Interfaces.IHaveGeographicalLocation>" %>
<fieldset>
    <legend>Address</legend>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.StreetAddress) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.StreetAddress)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.StreetAddress)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.Suburb)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.Suburb)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.Suburb)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.City)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.City)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.City)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.PostCode)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.PostCode)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.PostCode)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.Provence)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.Provence)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.Provence)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.Country)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.Country)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.Country)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.Latitude)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.Latitude)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.Latitude)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.GeographicalLocation.Longitude)%>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.GeographicalLocation.Longitude)%>
        <%: Html.ValidationMessageFor(model => model.GeographicalLocation.Longitude)%>
    </div>
</fieldset>
