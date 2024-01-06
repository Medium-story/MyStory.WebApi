using System.Net;

namespace MyStory.Service.Exceptions;

public class BadRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    public override string TitleMessage { get; protected set; } = String.Empty;
}
