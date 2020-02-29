namespace TinyChat.Core.Client.Command
{
    internal class SendMessageModel
    {
        public string RoomName { get; set; }
        public string CreatorName { get; set; }
        public string Text { get; set;  }
    }
}