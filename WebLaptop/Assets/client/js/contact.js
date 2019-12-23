var contact = {
    init: function () {
        contact.registerEvent();
    },
    registerEvent: function () {
        contact.initMap();
    },
    initMap: function () {
        var uluru = { lat: parseFloat($("#hilat").val()), lng: parseFloat($("#hilng").val()) };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 17,
            center: uluru
        });

        var contentString = $('#hiAddress').val()

        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });

        var marker = new google.maps.Marker({
            position: uluru,
            map: map,
            title: $("#hiname").val()
        });
        infowindow.open(map, marker);
    }
}
contact.init();