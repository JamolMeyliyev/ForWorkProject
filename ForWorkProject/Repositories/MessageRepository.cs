using ForWorkProject.Context;
using ForWorkProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ForWorkProject.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;
    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Message> CreateMessageAsync(Message message)
    {
        _context.Messages.Add(message); 
        await _context.SaveChangesAsync();
        return message;
    }

    public async ValueTask DeleteMessageAsync(Message message)
    {
        message.Status = EMessageStatus.Deleted;
        await _context.SaveChangesAsync();
    }

    public async ValueTask<List<Message>?> GetAllMessagesAsync(Guid chatId)
    {
        return await _context.Messages.Where(s => s.ChatId == chatId).ToListAsync();
    }

    public async ValueTask<Message?> GetMessageAsync(Guid chatId, Guid messageId)
    {
        var message = await _context.Messages.FirstOrDefaultAsync(u => u.ChatId == chatId && u.Id == messageId);
        return message;
    }

    public async ValueTask<Message> UpdateMessageAsync(Message message)
    {
        _context.Messages.Update(message);
        await _context.SaveChangesAsync();
        return message;

    }
}
