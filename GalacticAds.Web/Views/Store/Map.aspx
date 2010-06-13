<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.Store>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Map of
    <%: Model.Name %>
    -
    <%: Model.GeographicalLocation.Latitude %>
    <%: Model.GeographicalLocation.Longitude %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">
    $(document).ready(function() {
        initialize();
    });
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
        var marker = new google.maps.Marker({position: latlng, title: name, map: map});
        //marker.setMap(map); 
        alert("post-marker " + name);
    } 
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Model.Name %></h2>
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
</asp:Content>
<%--
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
</html>--%>
