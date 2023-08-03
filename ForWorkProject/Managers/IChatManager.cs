using ForWorkProject.Models;

namespace ForWorkProject.Managers;
public interface IChatManager
{
    ValueTask<List<ChatModel>> GetChats();
    ValueTask<ChatModel> GetByChatId(Guid chatId);
    ValueTask<ChatModel> CreateChat(CreateChatModel model);
    ValueTask<ChatModel> UpdateChat(Guid chatId,UpdateChatModel model);
    ValueTask DeleteChat(Guid chatId);

}
