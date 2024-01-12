namespace MyStory.Service.Exceptions.ReplyException;

public class ReplyNullException : ArgumentNullException
{
    public ReplyNullException()
    {
        TitleMessage = "Reply is null!";
    }
}
