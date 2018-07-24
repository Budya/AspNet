﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRMvc.Models;

namespace SignalRMvc.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();

        //отправка сообщений
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        //подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new User {ConnectionId = id, Name = userName});

                // посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // посылаем сообщение все пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);

            }
        }

        // отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}