using System;
using System.Linq;
using System.Threading;
using TinyChat.Core.Client;
using TinyChat.Core.Client.Interfaces;
using TinyChat.Core.Server;
using TinyChat.Core.Server.Interfaces;
using Xunit;
using Xunit.Extensions.Ordering;

namespace TinyChat.Core.ClientServer.Tests
{
    public class ClientServerWorkingTest
    {
        private const int ServerPort = 8002;
        private const string ServerIp = "127.0.0.1";
        
        [Fact, Order(0)]
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
        
        [Fact, Order(1)]
        public void Server_Should_Add_Message_By_Client_Request()
        {
            var server = GetRunningServer();
            var client = GetChatClient();
            
            var fakeCreator = "fakeCreator";
            var fakeMessage = "fakeMessage";
            
            client.SendMessage(ChatServer.DefaultChannel, fakeCreator, fakeMessage);

            Thread.Sleep(1000);
            
            server.Stop();

            var message = server.Chat.GetMessages(ChatServer.DefaultChannel).FirstOrDefault();
            Assert.NotNull(message);
            Assert.Equal(fakeCreator, message.SenderName);
            Assert.Equal(fakeMessage, message.Text);
            Assert.False(string.IsNullOrEmpty(message.SenderId));
        }

        [Fact, Order(2)]
        public void Client_Should_Receive_Rooms()
        {
            var server = GetRunningServer();
            var client = GetChatClient();

            var rooms = client.GetRooms();

            Thread.Sleep(1000);

            server.Stop();
            
            Assert.NotEmpty(rooms);
        }

        [Fact, Order(3)]
        public void Client_Should_Receive_Messages()
        {
            var server = GetRunningServer();
            var client = GetChatClient();
            
            client.SendMessage(ChatServer.DefaultChannel, "fakeUser", "fakeMessage");

            Thread.Sleep(1000);

            var messages = client.GetMessages(ChatServer.DefaultChannel);

            Thread.Sleep(1000);
            
            server.Stop();
            
            Assert.NotEmpty(messages);
        }
        
        private IChatClient GetChatClient()
        {
            return new ChatClient(ServerPort, ServerIp);
        }
        
        private IChatServer GetRunningServer()
        {
            var server = new ChatServer(ServerPort);
            server.Start();
            return server;
        }
    }
}