using TinyChat.Core.Client.Command;

namespace TinyChat.Core.Server
{
    internal partial class ChatServer
    {
        private void HandleCreateRoom(ChatCommand cmd)
        {
            _chat.CreateRoom(cmd.CreateRoomModel.CreatorName, cmd.SenderIdentifier, cmd.CreateRoomModel.RoomName);
        }

        private void HandleSendMessage(ChatCommand cmd)
        {
            _chat.SendMessage(cmd.SendMessageModel.RoomName, cmd.SendMessageModel.Text, cmd.SendMessageModel.CreatorName, cmd.SenderIdentifier);
        }
    }
}
