using FluentValidation;
using ForWorkProject.Entities;
using ForWorkProject.Exceptions;
using ForWorkProject.Models;
using ForWorkProject.Repositories;
using ForWorkProject.Validators;
using System.Net.WebSockets;

namespace ForWorkProject.Managers;

public class ChatManager : IChatManager
{
    private readonly IChatRepository _repos;
    public ChatManager(IChatRepository repos)
    {
        _repos = repos;
    }

    public async ValueTask<ChatModel> CreateChat(CreateChatModel model)
    {
        var validator = new CreateChatValidator();
        var result  = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new IsNotValidException("create chat model");
        }
        var chat = new Chat()
        {
            Name= model.Name,
            CreatedAt= DateTime.UtcNow,
            Description = model.Description,
            Messages = new List<Message>()

        };
         await _repos.CreateChatAsync(chat);
        return chat.ToModel();
        
    }

    public async ValueTask DeleteChat(Guid chatId)
    {
        var chat = await _repos.GetChatByChatIdAsync(chatId);
        if(chat is null)
        {
            throw new NotFoundException("chat");
        }
        await _repos.DeleteChatAsync(chat);
    }

    public async ValueTask<ChatModel> GetByChatId(Guid chatId)
    {
        var chat = await _repos.GetChatByChatIdAsync(chatId);
        if (chat is null)
        {
            throw new NotFoundException("chat");
        }
        return chat.ToModel();
    }

    public async ValueTask<IEnumerable<ChatModel>> GetChats(ChatFilter filter)
    {
        var chats =  await _repos.GetChatsAsync(filter);

        if(chats is null)
        {
            return new List<ChatModel>();
        }

        var chatModels = new List<ChatModel>();
        foreach(var chat in chats)
        {
            chatModels.Add(chat.ToModel());
        }
        return chatModels;
    }

    public async ValueTask<ChatModel> UpdateChat(Guid chatId,UpdateChatModel model)
    {
        var validator = new UpdateChatValidator();
        var result = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new IsNotValidException("update chat model");
        }

        var chat = await _repos.GetChatByChatIdAsync(chatId);

        if (chat is null)
        {
            throw new Exception("chat not found");
        }
        chat.Name = model.Name ?? chat.Name;
        chat.Description = model.Description ?? chat.Description;

        await _repos.UpdateChatAsync(chat);

        return chat.ToModel();
    }
}

