using ForWorkProject.Entities;

namespace ForWorkProject.Models;

public record MessageModel
(
  Guid Id,
  string MessageText, 
  EMessageStatus Status, 
  Guid? ParentMessageId, 
  List<Message>? ReplyMessages, 
  Guid ChatId 
);

public static class MessageExtension
{
    public static MessageModel ToModel(this Message message)
    {
       return new MessageModel(
           message.Id,
           message.MessageText,
           message.Status,
           message.ParentMessageId,
           message.ReplyMessages,
           message.ChatId
           );
    }
} 
        
    
