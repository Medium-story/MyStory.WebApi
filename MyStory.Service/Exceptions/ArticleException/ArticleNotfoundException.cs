namespace MyStory.Service.Exceptions.ArticleException;

public class ArticleNotfoundException : NotFoundException
{
    public ArticleNotfoundException()
    {
        TitleMessage = "Article Role not found!";
    }

    public ArticleNotfoundException(string errorText)
    {
        TitleMessage = errorText;
    }
}
