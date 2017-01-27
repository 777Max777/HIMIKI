﻿var geocoder;
var map;
function initialize(value) {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    var mapOptions = {
        zoom: 16,
        center: latlng
    }
    map = new google.maps.Map(document.getElementById("map"), mapOptions);

    /*var address = document.getElementById('address').value;

    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', map);
    var place = autocomplete.getPlace();

    var input = /** @type {!HTMLInputElement} (
      document.getElementById('address'));

    alert(place);
    search(address);*/
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

/*function search() {
    var address = document.getElementById('address').value;
    codeAddress(address, function (location) {
        //document.getElementById('output').innerHTML = location[0];
        alert(location[0]);
    });
}*/

/*function codeAddress(address, callback) {
    //var address = document.getElementById('address').value;
    var data=[];
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var lat = results[0].geometry.location.lat();
            var lon = results[0].geometry.location.lng();            
            location = new Array(lat, lon);
            callback(location);
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
    var html = 'Долгота: '+ data[0];
    document.getElementById("output").value = data[0];
    //alert(data[0]+","+data[1]);
}*/

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

   
/*function search(value) {        
    //var geocoder = new GClientGeocoder();
    //geocoder.setBaseCountryCode("en");
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
        alert (data);
    }
*/