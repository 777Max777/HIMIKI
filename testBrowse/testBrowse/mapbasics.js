/*var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init() {
    // Создание экземпляра карты и его привязка к контейнеру с
    // заданным id ("map").
    myMap = new ymaps.Map('map', {
        // При инициализации карты обязательно нужно указать
        // её центр и коэффициент масштабирования.
        center: [55.76, 37.64], // Москва
        zoom: 10,
        click: function (e) {
            alert('click');
    },
        searchControlProvider: 'yandex#search'
    });
}*/
/*var myMap;
function init()
{
    myMap = new GMaps({
        el: '#map',
        lat: -12.0433,
        lng: -77.0283,
        zoom: 12
    });
}*/
var map;

function initMap() {
    var myLatlng = new google.maps.LatLng(55.76, 37.64);

    map = new google.maps.Map(document.getElementById('map'), {
        center: myLatlng,
        zoom: 12
    });

    var marker = new google.maps.Marker({
    position: myLatlng,
    map:map,
    title: "Hello World!"   
    });
}

//marker.setMap(map);