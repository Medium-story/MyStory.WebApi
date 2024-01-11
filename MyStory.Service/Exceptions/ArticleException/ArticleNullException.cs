namespace MyStory.Service.Exceptions.ArticleException;

public class ArticleNullException : ArgumentNullException
{
    public ArticleNullException()
    {
        TitleMessage = "User is null!";
    }

    public ArticleNullException(string errorMessage)
    {
        TitleMessage = errorMessage;
    }
}
