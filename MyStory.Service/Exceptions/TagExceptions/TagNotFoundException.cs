namespace MyStory.Service.Exceptions.TagExceptions;

public class TagNotFoundException : NotFoundException
{
    public TagNotFoundException()
    {
        TitleMessage = "Tag Role not found!";
    }
    public TagNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}