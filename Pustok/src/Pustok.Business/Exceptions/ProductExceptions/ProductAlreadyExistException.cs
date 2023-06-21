using System.Net;

namespace Pustok.Business.Exceptions.ProductExceptions;

public sealed class ProductAlreadyExistException : Exception, IBaseException
{
    public ProductAlreadyExistException(string message) : base(message)
    {
        Message  = message;
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.Conflict;
    public string Message { get; set; }
}