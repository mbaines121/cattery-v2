namespace BuildingBlocks.Results.Result;

public abstract class ResultBase
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
}
