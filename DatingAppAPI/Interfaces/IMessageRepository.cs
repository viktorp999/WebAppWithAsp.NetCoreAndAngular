using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Helpers;

namespace DatingAppAPI.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<PagedList<MessageDto>> GetMessagesForUser(MessagesParams messagesParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientUserName);
    }
}
