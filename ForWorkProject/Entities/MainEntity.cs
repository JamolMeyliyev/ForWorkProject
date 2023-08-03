namespace ForWorkProject.Entities;

public class MainEntity<T> where T : struct
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class MainEntity : MainEntity<Guid>
{

}