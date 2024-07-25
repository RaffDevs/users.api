namespace Users.Api.Application.Exceptions;

public class NotFoundException : Exception
{
    public override string Message { get; }

    public NotFoundException(string? message)
    {
        Message = message ?? "No record has been found!";
    }
}