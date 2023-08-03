namespace ForWorkProject.Exceptions;

public class IsNotValidException:Exception
{
   public  IsNotValidException(string message) : base($"{message} is not valid") { }
}
