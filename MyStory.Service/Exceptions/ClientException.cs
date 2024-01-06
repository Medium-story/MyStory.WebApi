using System.Net;

namespace MyStory.Service.Exceptions;

public abstract class ClientException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public abstract string TitleMessage { get; protected set; }
}