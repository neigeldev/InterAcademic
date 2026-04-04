namespace Application.DTOs.Common;

public class ErrorResponse
{
    public string Message { get; set; } = null!;
    public string RequestId { get; set; } = null!;
}