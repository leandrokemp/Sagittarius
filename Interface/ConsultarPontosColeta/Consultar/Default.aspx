<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default.aspx.vb" Inherits="Interfaces_ConsultarPontosColeta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
        <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
        <title>Google Maps JavaScript API v3 Example: Geocoding Simple</title>
        <link href="http://code.google.com/apis/maps/documentation/javascript/examples/standard.css"
            rel="stylesheet" type="text/css" />

        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>

     <%--   <script src="http://maps.google.com/maps?file=api&v=1&key=ABQIAAAApPjKe_F7YonriHdbPZ9SOBS1WuRghNALx_mpD5kQuyBEUOhlFhThJQavY7vR49IFkI42GtcJUS9u1A"
            type="text/javascript"></script>--%>

        <script type="text/javascript">
            var geocoder;
            var map;
            var infowindow = new google.maps.InfoWindow();
            var marker;

//            function initialize() {
//                geocoder = new google.maps.Geocoder();
//                var latlng = new google.maps.LatLng(-14.179186, -50.449219);
//                var myOptions = {
//                    zoom: 4,
//                    center: latlng,
//                    mapTypeId: google.maps.MapTypeId.ROADMAP
//                }
//                map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
//            }
            
            //MOSTRAR ENDERECO
            function codeAddress() {
                geocoder = new google.maps.Geocoder();
                var address = document.getElementById("address").value;
                geocoder.geocode({ 'address': address }, function(results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        map.setCenter(results[0].geometry.location);
                        map.setZoom(12);
//                        var marker = new google.maps.Marker({
//                            map: map,
//                            position: results[0].geometry.location
//                        });
                    } else {
                        alert("Geocode was not successful for the following reason: " + status);
                    }
                });
            }
            
            //METODO PARA PEGAR LATITUDE CONVERTER EM ENDERECO
            function codeLatLng(Latitude) {

                if (geocoder == null) {
                    initialize();
                }
                var input = Latitude;
                var latlngStr = input.split(",", 2);
                var lat = parseFloat(latlngStr[0]);
                var lng = parseFloat(latlngStr[1]);
                var latlng = new google.maps.LatLng(lat, lng);


                geocoder.geocode({ 'latLng': latlng }, function(results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            map.setZoom(8);
                            marker = new google.maps.Marker({
                                position: latlng,
                                map: map
                            });
                            infowindow.setContent(results[0].formatted_address);
                            infowindow.open(map, marker);
                        }
                    } else {
                        alert("Geocoder failed due to: " + status);
                    }
                });

            }


            function createMarker(point, nombre) {
                var marker = new GMarker(point);
                GEvent.addListener(marker, 'click', function() {
                    marker.openInfoWindowHtml(nombre);
                });
                return marker;
            } 
        </script>

    </head>
    <body>
        <div>
            <input id="address" type="textbox" value="">
            <input type="button" value="Buscar Endereço" onclick="codeAddress()">
        </div>
        <div id="map_canvas" style="height: 90%">
        </div>
    </body>
    </html>
</asp:Content>
