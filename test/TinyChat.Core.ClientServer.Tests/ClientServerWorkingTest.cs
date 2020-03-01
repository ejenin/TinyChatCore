using System;
using System.Linq;
using TinyChat.Core.Client.Interfaces;
using TinyChat.Core.Server.Interfaces;
using Xunit;

namespace TinyChat.Core.ClientServer.Tests
{
    public class ClientServerWorkingTest
    {
        //1) server should add room by client request
        [Fact]
        public void Server_Should_Add_Room_By_Client_Request()
        {
            var server = GetRunningServer();
            var client = GetChatClient();

            var fakeRoom = "fakeRoom";
            var fakeCreator = "fakeCreator";
            
            client.CreateRoom(fakeRoom, fakeCreator);

            var createdRoom = server.Chat.GetRooms().FirstOrDefault(r => r.Name == fakeRoom);
            Assert.NotNull(createdRoom);
            Assert.Equal(fakeRoom, createdRoom.Name);
            Assert.Equal(fakeCreator, createdRoom.Creator);
            Assert.NotEqual(string.Empty, createdRoom.CreatorId);
        }
        
        private IChatClient GetChatClient()
        {
            throw new NotImplementedException();
        }
        
        private IChatServer GetRunningServer()
        {
            throw new NotImplementedException();
        }
    }
}