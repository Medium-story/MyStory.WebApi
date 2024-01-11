namespace MyStory.Service.Exceptions.TagExceptions;

public class TagNullException : ArgumentNullException
{
    public TagNullException()
    {
        TitleMessage = "Tag is null!";
    }
}