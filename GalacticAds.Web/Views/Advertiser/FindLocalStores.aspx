﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GalacticAds.Web.Models.ViewModels.ProximityResult>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Map of
    <%: Model.Record.Name %>
    -
    <%: Model.Record.Latitude %>
    <%: Model.Record.Longitude%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            initialize();
        });
        function initialize() {
            alert("enter");
            var lat = <%: Model.Record.Latitude %>
            var lng = <%: Model.Record.Longitude %>
            var latlng = new google.maps.LatLng(lat, lng);
            alert(latlng);

            var myOptions = {
                zoom: 12,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP };
            var element = document.getElementById("map_canvas")
            var map = new google.maps.Map(element, myOptions);

            var name = "<%: Model.Record.Name %>"
            alert("pre-marker " + name);
            var marker = new google.maps.Marker({position: latlng, title: name, map: map});
            alert("post-marker " + name);

            <% foreach (var association in Model.Associations) { %>  
            var marker = new google.maps.Marker({position: new google.maps.LatLng(<%: association.Latitude %>, <%: association.Longitude %>), 
                                                title: "<%: association.Name %>", 
                                                map: map}); 
            <% } %>  
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: Model.Record.Name%></h2>
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
</asp:Content>
