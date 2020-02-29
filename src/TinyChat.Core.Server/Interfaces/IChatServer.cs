using TinyChat.Core.Client.Command;
using TinyChat.Core.Domain.Interfaces;

namespace TinyChat.Core.Server.Interfaces
{
    internal interface IChatServer
    {
        /// <summary>
        /// Создаёт чат и подгружает из кеша (если есть)
        /// </summary>
        void InitServer();
        
        /// <summary>
        /// Сохраняет состояние в кеш
        /// </summary>
        void SaveState();
        
        /// <summary>
        /// Восстанавливает состояние из кеша
        /// </summary>
        void RestoreState();
        
        /// <summary>
        /// Стартует сервер (начинает слушать входящие команды)
        /// </summary>
        void Start();
        
        /// <summary>
        /// Останавливает сервер (и закрывает все соединения)
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Обрабатывает команду от клиента
        /// </summary>
        /// <param name="command">Пришедшая от клиента команда</param>
        void HandleCommand(ChatCommand command);
        
        /// <summary>
        /// Инстанс чата, выведен сюда в основном для тестов
        /// </summary>
        IChat Chat { get; }
    }
}