namespace MyStory.Service.Exceptions.CommentException;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException()
    {
        TitleMessage = "Comment Role not found!";
    }
    public CommentNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
