namespace Exadel.Compreface.Exceptions;

public class ServiceTimeoutException : Exception
{
    public ServiceTimeoutException()
    { }

    public ServiceTimeoutException(string message)
        : base(message)
    { }

    public ServiceTimeoutException(string message, Exception inner)
        : base(message, inner)
    { }
}