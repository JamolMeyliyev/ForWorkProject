using ForWorkProject.Models;

namespace ForWorkProject.Managers;

public interface IMessageManager
{
    ValueTask<List<MessageModel>> GetAllMessages(Guid chatId);
    ValueTask<MessageModel> GetMessage(Guid chatId,Guid messageId);
    ValueTask<MessageModel> CreateMessage(Guid chatId, CreateMessageModel model);
    ValueTask<MessageModel> UpdateMessage(Guid chatId,Guid messageId, UpdateMessageModel model);
    ValueTask DeleteMessage(Guid chatId, Guid messageId);
}
