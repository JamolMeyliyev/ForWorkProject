using ForWorkProject.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace ForWorkProject.Models;

public record ChatModel
(
     Guid Id,
     DateTime CreatedAt,
     string Name,
     string? Description,
     List<MessageModel> Messages  
);

public static class ChatExtension
{
    public static ChatModel ToModel(this Chat chat)
    { 
        var messageModels = new List<MessageModel>();

        if(chat.Messages is not null)
        {
            foreach(var message in chat.Messages)
            {
                messageModels.Add(message.ToModel());
            }
        }
        
        return new ChatModel(chat.Id, chat.CreatedAt, chat.Name, chat.Description, messageModels);
    }
}

