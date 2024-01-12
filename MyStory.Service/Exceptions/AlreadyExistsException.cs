using System.Net;

namespace MyStory.Service.Exceptions;

public class AlreadyExistsException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; set; } = String.Empty;
}