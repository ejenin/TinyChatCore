using System.Collections.Generic;
using TinyChat.Core.Client.Models;

namespace TinyChat.Core.Client.Interfaces
{
    public interface IChatClient
    {
        void CreateRoom(string roomName, string creatorName);
        void SendMessage(string roomName, string creatorName, string message);
        List<Room> GetRooms();
        List<Message> GetMessages(string roomName);
    }
}