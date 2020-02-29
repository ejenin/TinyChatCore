namespace TinyChat.Core.Client.Command
{
    internal class ChatCommand
    {
        public CommandType Type { get; set; }
        
        /// <summary>
        /// Supposed to be filled in server
        /// </summary>
        public string SenderIdentifier { get; set; }
        
        public CreateRoomModel CreateRoomModel { get; set; }
        public GetMessagesModel GetMessagesModel { get; set; }
        public SendMessageModel SendMessageModel { get; set; }
    }
}