using TinyChat.Core.Client.Command;
using TinyChat.Core.Domain.Interfaces;

namespace TinyChat.Core.Server.Interfaces
{
    internal interface IChatServer
    {
        void InitServer();
        void SaveState();
        void RestoreState();
        void Start();
        void Stop();
        void HandleCommand(ChatCommand command);
        IChat Chat { get; }
    }
}