namespace MyStory.Service.Exceptions.LikeException;

public class LikeBadRequestException : BadRequestException
{
    public LikeBadRequestException()
    {
        TitleMessage = "Like creation failed! Check like details and try again.";
    }

    public LikeBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}
