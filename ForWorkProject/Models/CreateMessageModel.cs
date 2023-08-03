namespace ForWorkProject.Models;

public class CreateMessageModel
{
    public required string MessageText { get; set; }
    public Guid? ParentMessageId { get; set; }

}
