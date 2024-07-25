namespace Users.Api.Application.Exceptions;

public class NotFoundException
{
    public string Message { get; private set; }

    public NotFoundException(string? message)
    {
        Message = message ?? "No record has been found!";
    }
}