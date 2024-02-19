using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Helpers;

namespace DatingAppAPI.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(Guid id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessagesParams messagesParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientUserName);
    }
}
