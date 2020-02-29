using System;
using System.Linq;
using TinyChat.Core.Client.Command;
using TinyChat.Core.Server.Interfaces;
using Xunit;

namespace TinyChat.Core.Server.Tests
{
    public class TinyChatServerTest
    {
        private const string DefaultRoom = "Default";
        
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
            var server = GetDummyChatServer_With_Default_Room();
            
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
            var server = GetDummyChatServer_With_Default_Room();

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

            var message = emptyServer.Chat.GetMessages(DefaultRoom).FirstOrDefault();
            Assert.NotNull(message);
            Assert.Equal(fakeMessage, message.Text);
            Assert.Equal(fakeCreator, message.SenderName);
            Assert.Equal(fakeId, message.SenderId);
        }

        private IChatServer GetDummyChatServer()
        {
            throw new NotImplementedException();
        }
        
        private IChatServer GetDummyChatServer_With_Default_Room()
        {
            throw new NotImplementedException();
        }
    }
}