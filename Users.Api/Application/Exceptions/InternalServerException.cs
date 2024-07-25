namespace Users.Api.Application.Exceptions;

public class InternalServerException : Exception
{
    public override string Message { get; }

    public InternalServerException(string? message)
    {
        Message = $"Unexpected error occured: {message}" ?? "Unexpected error occured!";
    }
}