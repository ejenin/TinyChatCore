namespace TinyChat.Core.Client.Command
{
    internal class ChatCommand
    {
        CommandType Type { get; set; }
        
        public CreateRoomModel CreateRoomModel { get; set; }
        public GetMessagesModel GetMessagesModel { get; set; }
        public SendMessageModel SendMessageModel { get; set; }
    }
}