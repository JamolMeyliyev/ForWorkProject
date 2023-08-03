using FluentValidation;
using ForWorkProject.Entities;
using ForWorkProject.Exceptions;
using ForWorkProject.Models;
using ForWorkProject.Repositories;
using ForWorkProject.Validators;

namespace ForWorkProject.Managers
{
    public class MessageManager : IMessageManager
    {
        private readonly IMessageRepository _repos;
        public MessageManager(IMessageRepository repos)
        {
            _repos = repos;
        }

        public async ValueTask<MessageModel> CreateMessage(Guid chatId, CreateMessageModel model)
        {
            var validator = new CreateMessageValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new IsNotValidException("create message model");
            }
            var message = new Message() 
            { 
                MessageText= model.MessageText,
                CreatedAt= DateTime.UtcNow,              
                ChatId=chatId, 
                ReplyMessages = new List<Message>(),
                ParentMessageId = model.ParentMessageId
            };
            await _repos.CreateMessageAsync(message);
            return  message.ToModel(); 
            
        }

        public async ValueTask DeleteMessage(Guid chatId, Guid messageId)
        {
            var message = await _repos.GetMessageAsync(chatId, messageId);
            if(message == null)
            {
                throw new NotFoundException("message");
            }
            await _repos.DeleteMessageAsync(message);
            
        }

        public async ValueTask<List<MessageModel>> GetAllMessages(Guid chatId)
        {
            var messages = await _repos.GetAllMessagesAsync(chatId);

            if(messages is null)
            {
                return new List<MessageModel>();
            }

            var messageModels = new List<MessageModel>();

            foreach(var message in messages)
            {
                messageModels.Add(message.ToModel());
            }
            return messageModels;
        }

        public async ValueTask<MessageModel> GetMessage(Guid chatId, Guid messageId)
        {
            var message = await _repos.GetMessageAsync(chatId, messageId);

            if(message == null)
            {
                throw new NotFoundException("message");
            }
            return message.ToModel();
        }

        public async ValueTask<MessageModel> UpdateMessage(Guid chatId, Guid messageId, UpdateMessageModel model)
        {
            var validator = new UpdateMessageValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new IsNotValidException("update message model");
            }
            var message = await _repos.GetMessageAsync(chatId, messageId);
            if (message == null)
            {
                throw new NotFoundException("message");
            }
            message.MessageText = model.MessageText ?? message.MessageText;
            await _repos.UpdateMessageAsync(message);
            return message.ToModel();

        }
    }
}
