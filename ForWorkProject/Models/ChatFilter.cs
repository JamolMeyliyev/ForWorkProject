using ForWorkProject.Helper;

namespace ForWorkProject.Models;

public class ChatFilter:PaginationParams
{
    public string? UserName { get; set; }
    public string? Descriction { get; set; }
    public DateTime? ToCreatedAt { get; set; }
    public DateTime? FromCreatedAt { get; set; }
}
