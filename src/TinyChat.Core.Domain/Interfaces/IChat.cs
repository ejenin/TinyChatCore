using System.Collections.Generic;
using TinyChat.Core.Domain.Models;

namespace TinyChat.Core.Domain.Interfaces
{
    public interface IChat
    {
        void CreateRoom(string creatorName, string creatorId, string roomName);
        void SendMessage(string room, string message, string creatorName, string creatorId);
        List<Message> GetMessages(string room);
        List<Room> GetRooms();
    }
}