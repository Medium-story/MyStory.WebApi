namespace MyStory.Service.Exceptions.TagExceptions;

public class TagBadRequestException : BadRequestException
{
    public TagBadRequestException()
    {
        TitleMessage = "Tag creation failed! Check teg details and try again.";
    }

    public TagBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}