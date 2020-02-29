using System;

namespace TinyChat.Core.Domain.Models
{
    public class Message
    {
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}