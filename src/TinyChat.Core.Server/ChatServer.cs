using Newtonsoft.Json;
using System;
using System.IO;
using TinyChat.Core.Client.Command;
using TinyChat.Core.Domain;
using TinyChat.Core.Domain.Interfaces;
using TinyChat.Core.Server.Interfaces;

namespace TinyChat.Core.Server
{
    internal partial class ChatServer : IChatServer
    {
        private IChat _chat;
        public static string CacheName = "chat.json";
        public static string DefaultChannel = "Main";
        private const string DefaultUser = "System";
        private const string DefaultId = "System";

        public IChat Chat => _chat;

        public ChatServer()
        {
            InitChat();
        }

        public void InitChat()
        {
            if (File.Exists(CacheName))
            {
                RestoreState();
            }
            else
            {
                _chat = new Chat();
                _chat.CreateRoom(DefaultUser, DefaultId, DefaultChannel);
            }
        }

        public void RestoreState()
        {
            _chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(CacheName));
        }

        public void SaveState()
        {
            var json = JsonConvert.SerializeObject(_chat);
            File.WriteAllText(CacheName, json);
        }

        public void HandleCommand(ChatCommand command)
        {
            switch (command.Type)
            {
                case CommandType.CreateRoom:
                    HandleCreateRoom(command);
                    break;
                case CommandType.SendMessage:
                    HandleSendMessage(command);
                    break;
                case CommandType.GetMessages:
                    throw new NotImplementedException();
                case CommandType.GetRooms:
                    throw new NotImplementedException();
            }
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}
