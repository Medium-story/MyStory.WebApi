namespace MyStory.Service.Exceptions.ReactionRxception;

public class ReactionBadRequestException : BadRequestException
{
    public ReactionBadRequestException()
    {
        TitleMessage = "Reaction creation failed! Check reaction details and try again.";
    }

    public ReactionBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}
