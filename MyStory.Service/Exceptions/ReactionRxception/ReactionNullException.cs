

namespace MyStory.Service.Exceptions.ReactionRxception;

public class ReactionNullException : ArgumentNullException
{
    public ReactionNullException()
    {
        TitleMessage = "Reaction is null!";
    }

    public ReactionNullException(string errorMessage)
    {
        this.TitleMessage = errorMessage;
    }
}
