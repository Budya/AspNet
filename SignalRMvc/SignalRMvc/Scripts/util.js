$(function() {
    $("#chatBody").hide();
    $("#loginBlock").show();

    // ссылка на автоматически сгенерированный прокси хаба
    var chat = $.connection.chatHub;

    // объявление функции которая вызывает хаб при получении сообщения
    chat.client.addMessage = function(name, message) {
        // добавление сообщения на страницу
        $("#chatroom").append('<p><b>' + htmlEncode(name) + '</b>:' + htmlEncode(message) + '</p>');
    };

    // функция вызываемая при подключении нового пользователя
    chat.client.onConnected = function(id, userName, allUsers) {
        $("#loginBlock").hide();
        $("#chatBody").show();

        // устанвока в скрытых полях имени и id текущего пользователя
        $("#hdId").val(id);
        $("#username").val(userName);
        $("#header").html('<h3>Добро пожаловать, ' + userName + '</h3');

        // Добавление всех пользователей
        for (i = 0; i < allUsers.length; i++) {
            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    }

    chat.client.onNewUserConnected = function(id, name) {
        AddUser(id, name);
    }

    // Удаляем пользователя
    chat.client.onUserDisconnected = function(id, userName) {
        $("#" + id).remove();
    }

    // открываем соединение
    $.connection.hub.start().done(function() {
        $("#sendmessage").click(function() {
            // вызываем у хаба метод Send
            chat.server.send($("#username").val(), $("#message").val());
            $("#message").val();
        });

        // обработка логина
        $("#btnLogin").click(function() {
            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            } else {
                alert("Введите имя");
            }
        });
    });
});

// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $("<div/>").text(value).html();
    return encodedValue;
}

// Добавление нового пользователя
function AddUser(id, name) {
    var userId = $("#hdId").val();

    if (userId != id) {
        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');

    }
}

