using System;
using System.Collections.Generic;
using System.Linq;
using TinyChat.Core.Domain.Interfaces;
using TinyChat.Core.Domain.Models;

namespace TinyChat.Core.Domain
{
    public class Chat : IChat
    {
        private List<Room> _rooms;

        public Chat()
        {
            _rooms = new List<Room>();
        }
        
        public void CreateRoom(string creatorName, string creatorId, string roomName)
        {
            _rooms.Add(new Room()
            {
                Creator = creatorName,
                CreatorId = creatorId,
                Name = roomName,
                
                Messages = new List<Message>()
            });
        }

        public void SendMessage(string roomName, string message, string creatorName, string creatorId)
        {
            var room = _rooms.FirstOrDefault(r => r.Name == roomName);
            
            room.Messages.Add(new Message()
            {
                CreatedDate = DateTime.Now,
                SenderId = creatorId,
                SenderName = creatorName,
                Text = message
            });
        }

        public List<Message> GetMessages(string roomName)
        {
            var room = _rooms.FirstOrDefault(r => r.Name == roomName);

            return room.Messages;
        }

        public List<Room> GetRooms()
        {
            return _rooms;
        }
    }
}