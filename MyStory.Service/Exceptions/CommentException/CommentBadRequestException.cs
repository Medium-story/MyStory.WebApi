namespace MyStory.Service.Exceptions.CommentException;

public class CommentBadRequestException : BadRequestException
{
    public CommentBadRequestException()
    {
        TitleMessage = "Comment creation failed! Check comment details and try again.";
    }

    public CommentBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}
