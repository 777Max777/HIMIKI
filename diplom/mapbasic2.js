var geocoder;
var map;

function initialize(value) {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(51.68439, 39.185851);
    var mapOptions = {
        zoom: 16,
        center: latlng
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

function codeAddressMy() {
    var latitude = document.getElementById('lat').value;
    var longitude = document.getElementById('lng').value;
    var myLatlng = new google.maps.LatLng(latitude, longitude);
    map.setCenter(myLatlng);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map
    });
}


