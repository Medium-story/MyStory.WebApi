namespace MyStory.Service.Exceptions.UserExceptions;

internal class UserNotFoundException : NotFoundException
{
    public UserNotFoundException()
    {
        TitleMessage = "User Role not found!";
    }

    public UserNotFoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
