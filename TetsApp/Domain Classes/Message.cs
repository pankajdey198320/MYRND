using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TetsApp.Domain_Classes
{
    public class Message
    {
        public string IncomingMessage { set; get; }
    }

    internal class MessageController
    {
       public static List<Message> GetAllMessage()
        {
            return (List<Message>)HttpContext.Current.Session[CommonConstant.Message];
        }
       public static void AddMessage(string Message)
       {
           var messageList = (List<Message>)HttpContext.Current.Session[CommonConstant.Message];
           if (messageList == null)
           {
               messageList = new List<Message>();
           }
           messageList.Add(new Message() { IncomingMessage = Message });
           HttpContext.Current.Session[CommonConstant.Message] = messageList;

       }
    }
}