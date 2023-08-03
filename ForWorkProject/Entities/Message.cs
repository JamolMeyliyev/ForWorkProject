using System.Text.Json.Serialization;

namespace ForWorkProject.Entities;

public class Message: MainEntity
{
    public required string MessageText { get; set; }
    public EMessageStatus Status { get; set; }
    public Guid? ParentMessageId { get; set; }
    public List<Message>? ReplyMessages { get; set; }
    public Guid ChatId { get; set; }
    [JsonIgnore]
    public virtual Chat? Chat { get; set; }

}
