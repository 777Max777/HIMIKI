var geocoder;
var map;
function initialize() {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    var mapOptions = {
        zoom: 16,
        center: latlng
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);
    codeAddress();
}

function codeAddress() {
    var address = document.getElementById("address").value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var rad = document.getElementsByName("flag")
            if (rad[0].checked) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    icon:"http://maps.google.com/mapfiles/ms/icons/red-dot.png"
                });
            }
            if (rad[1].checked) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    icon: "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                });
            }
            if (rad[2].checked) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    icon: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"
                });
            }
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}