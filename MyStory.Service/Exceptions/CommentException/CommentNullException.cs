namespace MyStory.Service.Exceptions.CommentException;

public class CommentNullException : ArgumentNullException
{
    public CommentNullException()
    {
        TitleMessage = "Comment is null!";
    }
}
