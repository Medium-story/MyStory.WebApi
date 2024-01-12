namespace MyStory.Service.Exceptions.LikeException;

public class LikeNotFoundException : NotFoundException
{
    public LikeNotFoundException()
    {
        TitleMessage = "Tag Role not found!";
    }
    public LikeNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
