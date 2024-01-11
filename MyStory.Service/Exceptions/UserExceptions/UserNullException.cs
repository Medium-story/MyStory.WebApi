namespace MyStory.Service.Exceptions.UserExceptions;

public class UserNullException : ArgumentNullException
{
    public UserNullException()
    {
        TitleMessage = "User is null!";
    }

    public UserNullException(string errorMessage)
    {
        this.TitleMessage = errorMessage;
    }
}
