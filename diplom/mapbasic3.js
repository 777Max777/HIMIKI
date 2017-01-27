var geocoder;
var map;
var mark;
var lat;
var lng;
function initialize(value) {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(51.68439, 39.185851);
    var mapOptions = {
        zoom: 16,
        center: latlng
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);

    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng);
    });//добавляем событие нажание мышки
}

function codeAddressMy() {
    document.getElementById('lat').innerText = lat;
    document.getElementById('lng').innerText = lng;
}

function addMarker(location) {
   if (mark) {
        mark.setMap(null);
    }
    mark = new google.maps.Marker({
        position: location,
        map: map
    });
    lat = location.lat();
    lng = location.lng();
}


