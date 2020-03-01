using System;
using System.IO;
using System.Linq;
using TinyChat.Core.Client.Command;
using TinyChat.Core.Server.Interfaces;
using Xunit;

namespace TinyChat.Core.Server.Tests
{
    public class TinyChatServerTest : IDisposable
    {
        private static string DefaultRoom = ChatServer.DefaultChannel;
        
        [Fact]
        public void Server_Should_Handle_AddRoom()
        {
            var server = GetDummyChatServer();
            
            var fakeCreator = "fakeCreator";
            var fakeId = "fakeId";
            var fakeRoom = "fakeRoom";
            
            server.HandleCommand(new ChatCommand()
            {
                Type = CommandType.CreateRoom,
                
                SenderIdentifier = fakeId,
                
                CreateRoomModel = new CreateRoomModel()
                {
                    RoomName = fakeRoom,
                    CreatorName = fakeCreator
                }
            });

            var room = server.Chat.GetRooms().FirstOrDefault(r => r.Name == fakeRoom);
            Assert.NotNull(room);
            Assert.Equal(fakeCreator, room.Creator);
            Assert.Equal(fakeId, room.CreatorId);
        }
        
        [Fact]
        public void Server_Should_Add_Message()
        {
            var server = GetDummyChatServer();
            
            var fakeMessage = "fakeMessage";
            var fakeCreator = "fakeCreator";
            var fakeId = "fakeId";
            
            server.HandleCommand(new ChatCommand()
            {
                Type = CommandType.SendMessage,
                
                SenderIdentifier = fakeId,
                
                SendMessageModel = new SendMessageModel()
                {
                    CreatorName = fakeCreator,
                    Text = fakeMessage,
                    RoomName = DefaultRoom
                }
            });

            var messages = server.Chat.GetMessages(DefaultRoom);
            Assert.Single(messages);

            var message = messages.First();
            Assert.Equal(fakeMessage, message.Text);
            Assert.Equal(fakeCreator, message.SenderName);
            Assert.Equal(fakeId, message.SenderId);
        }
        
        [Fact]
        public void Server_Should_Save_State()
        {
            var server = GetDummyChatServer();

            var fakeMessage = "fakeMessage";
            var fakeCreator = "fakeCreator";
            var fakeId = "fakeId";
            
            server.HandleCommand(new ChatCommand()
            {
                Type = CommandType.SendMessage,
                
                SenderIdentifier = fakeId,
                
                SendMessageModel = new SendMessageModel()
                {
                    CreatorName = fakeCreator,
                    Text = fakeMessage,
                    RoomName = DefaultRoom
                }
            });
            
            server.SaveState();

            var emptyServer = GetDummyChatServer();
            emptyServer.RestoreState();

            Assert.Single(emptyServer.Chat.GetRooms());

            var message = emptyServer.Chat.GetMessages(DefaultRoom).FirstOrDefault();
            Assert.NotNull(message);
            Assert.Equal(fakeMessage, message.Text);
            Assert.Equal(fakeCreator, message.SenderName);
            Assert.Equal(fakeId, message.SenderId);
        }

        private IChatServer GetDummyChatServer()
        {
            return new ChatServer(-1);
        }

        public void Dispose()
        {
            if (File.Exists(ChatServer.CacheName))
            {
                File.Delete(ChatServer.CacheName);
            }
        }
    }
}