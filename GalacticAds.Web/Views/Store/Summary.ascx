<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GalacticAds.Web.Models.Store>" %>
<div>
    <h2><%: Model.Name %></h2>
    <%:Model.GeographicalLocation.ToString() %>
</div>
