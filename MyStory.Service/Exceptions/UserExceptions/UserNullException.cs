namespace MyStory.Service.Exceptions.UserExceptions;

public class UserNullException : ArgumentNullException
{
    public UserNullException()
    {
        TitleMessage = "User is null!";
    }
}
