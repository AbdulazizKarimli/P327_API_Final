namespace Pustok.Business.Exceptions.AuthExceptions;

public sealed class LoginFailedException : Exception, IBaseException
{
    public LoginFailedException(string message) : base(message)
    {
        Message = message;
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.Unauthorized;
    public string Message { get; set; }
}