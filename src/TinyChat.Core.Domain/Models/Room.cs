using System.Collections.Generic;

namespace TinyChat.Core.Domain.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public string CreatorId { get; set; }
        
        public List<Message> Messages { get; set; }
    }
}