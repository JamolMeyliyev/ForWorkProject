using ForWorkProject.Context;
using ForWorkProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForWorkProject.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;
    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<List<Chat>?> GetChatsAsync()
    {
        var chats = await _context.Chats.Include(s => s.Messages)?.ThenInclude(s => s.ReplyMessages).ToListAsync();

        return chats;
    }

    public async ValueTask<Chat?> GetChatByChatIdAsync(Guid chatId)
    {
        return await _context.Chats.FirstOrDefaultAsync(u => u.Id == chatId);
    }

    public async ValueTask<Chat> CreateChatAsync(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async ValueTask<Chat> UpdateChatAsync(Chat chat)
    {
        _context.Chats.Update(chat);
        await _context.SaveChangesAsync();
        return chat;
    }
    public async ValueTask DeleteChatAsync(Chat chat)
    {
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
    }

}
