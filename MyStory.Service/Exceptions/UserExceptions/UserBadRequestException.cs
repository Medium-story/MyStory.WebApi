namespace MyStory.Service.Exceptions.UserExceptions;

public class UserBadRequestException : BadRequestException
{
    public UserBadRequestException()
    {
        TitleMessage = "User creation failed! Check user details and try again.";
    }

    public UserBadRequestException(string errorText)
    {
        TitleMessage = errorText;
    }
}
