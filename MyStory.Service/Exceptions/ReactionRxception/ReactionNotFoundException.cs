namespace MyStory.Service.Exceptions.ReactionRxception;

public class ReactionNotFoundException : NotFoundException
{
    public ReactionNotFoundException()
    {
        TitleMessage = "Reaction Role not found!";
    }

    public ReactionNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
