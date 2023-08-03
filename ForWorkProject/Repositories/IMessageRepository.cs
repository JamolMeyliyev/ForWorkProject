using ForWorkProject.Entities;

namespace ForWorkProject.Repositories;

public interface IMessageRepository
{
    ValueTask<List<Message>?> GetAllMessagesAsync(Guid chatId);
    ValueTask<Message?> GetMessageAsync(Guid chatId,Guid messageId);
    ValueTask<Message> CreateMessageAsync(Message message);
    ValueTask<Message> UpdateMessageAsync(Message message);
    ValueTask DeleteMessageAsync(Message message);

}
