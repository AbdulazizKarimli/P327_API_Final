using System.Net;

namespace Pustok.Business.Exceptions.CategoryExceptions;

public sealed class CategoryAlreadyExistException : Exception, IBaseException
{
    public CategoryAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.Conflict;
    public string Message { get; set; }
}