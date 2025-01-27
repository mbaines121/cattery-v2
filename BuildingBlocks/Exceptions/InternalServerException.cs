namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string? message) : base(message)
    {
    }

    public InternalServerException(string? message, string? details) : base(message)
    {
        Details = details ?? string.Empty;
    }

    public string? Details { get; }
}
