<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GalacticAds.Web.Models.Interfaces.IHaveGeographicalLocation>" %>
<fieldset>
    <legend>Address</legend>
    <span class="display-label">
        Street Address
    </span>
    <div class="display-field">
        <%:Model.GeographicalLocation.StreetAddress %>
    </div>
    <span class="display-label">
        Suburb
    </span>
    <div class="display-field">
        <%: Model.GeographicalLocation.Suburb %>
    </div>
    <span class="display-label">
        City
    </span>
    <div class="display-field">
        <%: Model.GeographicalLocation.City%>
    </div>
    <span class="display-label">
        PostCode
    </span>
    <div class="display-field">
        <%: Model.GeographicalLocation.PostCode%>
    </div>
    <span class="display-label">
        Provence
    </span>
    <div class="display-field">
        <%:Model.GeographicalLocation.Provence%>
    </div>
    <span class="display-label">
        Country
    </span>
    <div class="display-field">
        <%:Model.GeographicalLocation.Country%>
    </div>
    <span class="display-label">
        Latitude
    </span>
    <div class="display-field">
        <%: Model.GeographicalLocation.Latitude %>
    </div>
    <span class="display-label">
        Longitude
    </span>
    <div class="display-field">
        <%: Model.GeographicalLocation.Longitude%>
    </div>
</fieldset>
