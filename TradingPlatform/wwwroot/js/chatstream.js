$(document).ready(function () {
    var protocol = location.protocol === "https:" ? "wss:" : "ws:";
    var wsUri = protocol + "//" + window.location.host;
    var socket = new WebSocket(wsUri);


    socket.onmessage = function (e) {
        $('#msgs').prepend(e.data + '<br />');
    };

    $('#MessageField').keypress(function (e) {
        if (e.which != 13) {
            return;
        }

        e.preventDefault();

        var message = userName + ": " + $('#MessageField').val();
        socket.send(message);
        $('#MessageField').val('');
    });

});