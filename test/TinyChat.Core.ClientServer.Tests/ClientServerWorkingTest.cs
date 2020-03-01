using System;
using System.Linq;
using System.Threading;
using TinyChat.Core.Client;
using TinyChat.Core.Client.Interfaces;
using TinyChat.Core.Server;
using TinyChat.Core.Server.Interfaces;
using Xunit;

namespace TinyChat.Core.ClientServer.Tests
{
    public class ClientServerWorkingTest
    {
        private const int ClientPort = 8001;
        private const int ServerPort = 8002;
        private const string ServerIp = "127.0.0.1";
        
        //1) server should add room by client request
        [Fact]
        public void Server_Should_Add_Room_By_Client_Request()
        {
            var server = GetRunningServer();
            var client = GetChatClient();

            var fakeRoom = "fakeRoom";
            var fakeCreator = "fakeCreator";
            
            client.CreateRoom(fakeRoom, fakeCreator);

            Thread.Sleep(1000);
            
            server.Stop();

            var createdRoom = server.Chat.GetRooms().FirstOrDefault(r => r.Name == fakeRoom);
            Assert.NotNull(createdRoom);
            Assert.Equal(fakeRoom, createdRoom.Name);
            Assert.Equal(fakeCreator, createdRoom.Creator);
            Assert.False(string.IsNullOrEmpty(createdRoom.CreatorId));
        }
        
        private IChatClient GetChatClient()
        {
            return new ChatClient(ClientPort, ServerPort, ServerIp);
        }
        
        private IChatServer GetRunningServer()
        {
            var server = new ChatServer(ServerPort);
            server.Start();
            return server;
        }
    }
}