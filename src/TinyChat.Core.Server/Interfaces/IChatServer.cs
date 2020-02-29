using TinyChat.Core.Client.Command;

namespace TinyChat.Core.Server.Interfaces
{
    internal interface IChatServer
    {
        void SaveState();
        void RestoreState();
        void Start();
        void Stop();
        void HandleCommand(ChatCommand command);
    }
}