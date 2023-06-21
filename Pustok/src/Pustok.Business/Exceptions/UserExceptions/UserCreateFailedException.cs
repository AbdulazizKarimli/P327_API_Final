namespace Pustok.Business.Exceptions.UserExceptions;

public sealed class UserCreateFailedException : Exception, IBaseException
{
    public UserCreateFailedException(string message) : base(message)
    {
        Message = message;
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Message { get; set; }
}