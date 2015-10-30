var geocoder;
var map;
var marker;
var markers = [];
var uniqueID=1;
$('#dir').focusout(function () {
    var dir = document.getElementById('dir').value.trim();
    var direccion = dir + ',córdoba,argentina';
    if (dir.length > 0) {
            
        mostrarDireccion(direccion);
    }
    if (marker!=null) {
        marker.setMap(null);
    }
               
})
$(document).ready(function () {
    ini();
});

function ini() {
    crearMapa();
    // GetDireccion();
    crearMarker()
    /* $.getJSON('/Direccions/getDireccion', function (data) {
         alert(data);
     }).fail(function (jqXHR, textStatus, errorThrown) {
         // Ajax fail callback function.
         alert('Error cargando Direcciones!' + textStatus);
     });*/
}
function crearMapa() {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(-31.417321454065778,-64.18382406234741);
    var opc = {
        zoom: 12,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    map = new google.maps.Map(document.getElementById("map_canvas"), opc);

}
function marcar(localizacion) {
    if (marker != null) {
        marker.setMap(null);
    }
    marker = new google.maps.Marker({
        map: map,
        position: localizacion,
        title: localizacion
    });
    document.getElementById("lat").value = localizacion.lat();
    document.getElementById("lng").value = localizacion.lng();
    var infowindow = new google.maps.InfoWindow({
        content: 'Latitud: ' + localizacion.lat() + '<br> Longitud: ' + localizacion.lng()
    });
    marker.id = uniqueID;
    markers.push(marker);
    uniqueID++;
    infowindow.open(map, marker);
    marcarTextDir(localizacion);
    google.maps.event.addListener(marker, 'dblclick', function (event) {
        marker.setMap(null);
        document.getElementById("dir").value = null;
    });
}
function DeleteMarker(id) {
       
    //alert(id);
    for (var i = 0; i < markers.length; i++) {
        if (markers[i].id == id) {
                               
            markers[i].setMap(null);

            markers.splice(i, 1);
            return;
        }
    }
};
function marcarTextDir(latLng) {
    geocoder.geocode({ 'latLng': latLng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {        
            if (results[0]) {
                //alert(results[0].formatted_address);
                var direccion = results[0].formatted_address.split(",");
                document.getElementById("dir").value = direccion[0];
                document.getElementById("dir1").value = direccion[0];
            }
        }
    });
}
function crearMarker() {
    google.maps.event.addListener(map, 'click', function (event) {
        marcar(event.latLng);
    });

}
function mostrarDireccion(dir) {

    if (geocoder) {

        geocoder.geocode({ 'address': dir }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                    
                marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    title: dir
                });
                var infowindow = new google.maps.InfoWindow();
                infowindow.setContent(dir);
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });

            }
            else {
                alert('Error');
            }
        });
    }
}
/*function GetDireccion() {
    mostrarDireccion("independencia 27, cordoba", '5000');
}*/

