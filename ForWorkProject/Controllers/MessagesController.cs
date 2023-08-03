using ForWorkProject.Exceptions;
using ForWorkProject.Managers;
using ForWorkProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForWorkProject.Controllers
{
    [Route("api/chats/{chatId}/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageManager _messageManager;
        public MessagesController(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages(Guid chatId)
        {
            try
            {
                return Ok( await _messageManager.GetAllMessages(chatId) );
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("messageId")]
        public async Task<IActionResult> GetMessageByMessageId(Guid chatId,Guid messageId)
        {
            try
            {
                return Ok(await _messageManager.GetMessage(chatId, messageId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Guid chatId,[FromBody] CreateMessageModel model)
        {

            try
            {
                return Ok( await _messageManager.CreateMessage(chatId,model));
            }

            catch (IsNotValidException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("messageId")]
        public async Task<IActionResult> UpdateMessage(Guid chatId, Guid messageId, [FromBody] UpdateMessageModel model)
        {
            

            try
            {
                return Ok(await _messageManager.UpdateMessage(chatId, messageId,model));
            }

            catch(IsNotValidException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("messageId")]
        public async Task<IActionResult> DeleteMessage(Guid chatId,Guid messageId)
        {
            try
            {
                await _messageManager.DeleteMessage(chatId,messageId);
                return Ok();
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
