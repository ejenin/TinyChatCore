using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TinyChat.Core.Client.Command;
using TinyChat.Core.Domain;
using TinyChat.Core.Domain.Interfaces;
using TinyChat.Core.Server.Interfaces;

namespace TinyChat.Core.Server
{
    internal partial class ChatServer : IChatServer
    {
        public static string CacheName = "chat.json";
        public static string DefaultChannel = "Main";
        private const string DefaultUser = "System";
        private const string DefaultId = "System";

        private readonly int _serverPort;

        private UdpClient _client;
        private Thread _serverThread;
        private IChat _chat;
        private bool _serverRunning;

        public ChatServer(int serverPort)
        {
            InitChat();

            _serverPort = serverPort;
        }

        public IChat Chat => _chat;

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
                    HandleGetMessages(command);
                    break;
                case CommandType.GetRooms:
                    HandleGetRooms(command);
                    break;
            }
        }
        
        public void Start()
        {
            _serverRunning = true;
            _client = new UdpClient(_serverPort);
            _serverThread = new Thread(ThreadHandler);
            _serverThread.Start();
        }

        private void ThreadHandler()
        {
            while (_serverRunning)
            {
                try
                {
                    IPEndPoint ip = null;

                    var data = _client.Receive(ref ip);
                    var message = Encoding.UTF8.GetString(data);
                    var command = JsonConvert.DeserializeObject<ChatCommand>(message);

                    command.SenderIdentifier = ip.ToString();

                    HandleCommand(command);
                }
                catch (Exception)
                {
                    //todo: log
                }
            }
        }

        public void Stop()
        {
            _serverRunning = false;
            _client.Close();
            _client.Dispose();
            _serverThread.Abort();
        }
    }
}
