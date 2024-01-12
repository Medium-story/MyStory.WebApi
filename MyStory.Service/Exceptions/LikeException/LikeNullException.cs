namespace MyStory.Service.Exceptions.LikeException;

public class LikeNullException : ArgumentNullException
{
    public LikeNullException()
    {
        TitleMessage = "Like is null!";
    }
}
