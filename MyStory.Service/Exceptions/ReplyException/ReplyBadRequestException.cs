

namespace MyStory.Service.Exceptions.ReplyException;

public class ReplyBadRequestException : BadRequestException
{
    public ReplyBadRequestException()
    {
        TitleMessage = "Reply creation failed! Check teg details and reply again.";
    }

    public ReplyBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}
