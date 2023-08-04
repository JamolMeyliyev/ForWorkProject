using ForWorkProject.Entities;
using ForWorkProject.Models;

namespace ForWorkProject.Repositories;

public interface IChatRepository
{
    ValueTask<IEnumerable<Chat>?> GetChatsAsync(ChatFilter filter);
    ValueTask<Chat?> GetChatByChatIdAsync(Guid chatId);
    ValueTask<Chat> CreateChatAsync(Chat chat);
    ValueTask<Chat> UpdateChatAsync(Chat chat);
    ValueTask DeleteChatAsync(Chat chat);

}
