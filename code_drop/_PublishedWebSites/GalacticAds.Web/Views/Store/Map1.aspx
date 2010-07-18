<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Store>" %>

<html>
<head>
    <title>
        <%: Model.Name %>
        -
        <%: Model.GeographicalLocation.Latitude %>
        <%: Model.GeographicalLocation.Longitude %>
    </title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
    function initialize() {
        var lat = <%: Model.GeographicalLocation.Latitude %>
        var lng = <%: Model.GeographicalLocation.Longitude %>
        var latlng = new google.maps.LatLng(lat, lng);
        var myOptions = {
            zoom: 12,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var element = document.getElementById("map_canvas")
        var map = new google.maps.Map(element, myOptions);
        var name = "<%: Model.Name %>"
        alert("pre-marker " + name);
        var marker = new google.maps.Marker({position: latlng, title:name });
        marker.setMap(map); 
        alert("post-marker " + name);
    } 
 
    </script>
</head>
<body onload="initialize()">
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
</body>
</html>
<%--    <h2>Map</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>--%>
