using ForWorkProject.Exceptions;
using ForWorkProject.Managers;
using ForWorkProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForWorkProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatManager _chatManager;
    public ChatsController(IChatManager chatManager)
    {
        _chatManager = chatManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetChats([FromQuery] ChatFilter filter)
    {
        try
        {
           return Ok( await _chatManager.GetChats(filter));
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
    [HttpGet("chatId")]
    public async Task<IActionResult> GetByChatId(Guid chatId)
    {
        try
        {
            return Ok(await _chatManager.GetByChatId(chatId));
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

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatModel model)
    {
       
        try
        {
          return Ok( await _chatManager.CreateChat(model));
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

    [HttpPut("chatId")] 
    public async Task<IActionResult> UpdateChat(Guid chatId,[FromBody] UpdateChatModel model)
    {
        try
        {
            return Ok(await _chatManager.UpdateChat(chatId, model));
        }
        catch (IsNotValidException ex)
        {
            return BadRequest(ex.Message);
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
    [HttpDelete("chatId")]
    public async Task<IActionResult> DeleteChat(Guid chatId)
    {
        try
        {
            await _chatManager.DeleteChat(chatId);
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
