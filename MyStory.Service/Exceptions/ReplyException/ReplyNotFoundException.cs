

namespace MyStory.Service.Exceptions.ReplyException;

public class ReplyNotFoundException : NotFoundException
{
    public ReplyNotFoundException()
    {
        TitleMessage = "Reply Role not found!";
    }
    public ReplyNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
