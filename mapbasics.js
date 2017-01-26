var geocoder;
var map;
function initialize(value) {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    var mapOptions = {
        zoom: 16,
        center: latlng
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);
    codeAddress();
}

function codeAddressMy(value) {
    var geocoder = new google.maps.Geocoder();
    var address = value;
    var data;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            data = results[0].geometry.location;
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
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
                    icon: "red.png"
                });
            }
            if (rad[1].checked) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    icon: "green.png"
                });
            }
            if (rad[2].checked) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location,
                    icon: "blue.png"
                });
            }
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}

   /* geocoder.setBaseCountryCode("en");
    function search(value) {
        var geocoder = new GClientGeocoder();
        if (value != null) {
            geocoder.getLatLng(value, function (point) {
                if (!point) {
                    //ничего не найдено
                    alert("We couldn't find anything. Please try another search request");
                }
                else {
                    geocoder.getLocations(point, function (response) {
                        if (!response || response.Status.code != 200) {
                            //ничего не найдено
                            alert("We couldn't find anything. Please try another search request");
                        }
                        else {
                            var data = {
                                latitude: point.lat(),
                                longitude: point.lng(),
                                search: value
                            };
                        }
                    })
                }
            })
        }
        return data;
    }

}*/