namespace Users.Api.Application.Exceptions;

public class InternalServerException
{
    public string Message { get; private set; }

    public InternalServerException(string? message)
    {
        Message = $"Unexpected error occured: {message}" ?? "Unexpected error occured!";
    }
}