using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;
using System.Security.Principal;

namespace Api.SignalR.Chat.Models
{
    public class Message
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }

        public Message(string name, string body)
        {
            Name = name;
            Body = body;
            Date = DateTime.Now.ToString("G");
        }
    }
}
