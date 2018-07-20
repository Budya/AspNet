using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Web;

namespace ChatAspNet.Models
{
    public class ChatModel
    {
        public List<ChatUser> Users; //All chat users

        public List<ChatMessage> Messages; // Chat messages

        public ChatModel()
        {
            Users = new List<ChatUser>();
            Messages = new List<ChatMessage>();

            Messages.Add(new ChatMessage()
            {
                Text = "Чат запущен "+ DateTime.Now
            });
        }
    }

    public class ChatUser
    {
        public string Name;
        public DateTime LoginTime;
        public DateTime LastPing;
    }

    public class ChatMessage
    {
        // Author of message, if null - server is author
        public ChatUser User;
        // Time of message
        public DateTime Date = DateTime.Now;
        // text of message
        public string Text = "";
    }
}