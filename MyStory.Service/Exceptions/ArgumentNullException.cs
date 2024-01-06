using System.Net;

namespace MyStory.Service.Exceptions;

public class ArgumentNullException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
