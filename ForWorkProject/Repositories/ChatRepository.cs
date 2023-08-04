using ForWorkProject.Context;
using ForWorkProject.Entities;
using ForWorkProject.Helper;
using ForWorkProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ForWorkProject.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;
    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<IEnumerable<Chat>?> GetChatsAsync(ChatFilter filter)
    {
        var query =  _context.Chats.AsQueryable();
        if(filter.UserName is not null)
        {
            query = query.Where(c => c.Name.Contains(filter.UserName));
        }
        if(filter.FromCreatedAt is not null)
        {
            query = query.Where(c => c.CreatedAt>filter.FromCreatedAt);
        }
        if(filter.ToCreatedAt is not null)
        {
            query = query.Where(c => c.CreatedAt < filter.ToCreatedAt);
        }

        return await query.ToPageListAsync(filter);
        
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
