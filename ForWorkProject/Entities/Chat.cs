namespace ForWorkProject.Entities;

public class Chat : MainEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public virtual List<Message>? Messages { get; set; }
}



