namespace InteliTrack.Application.DTOs.Stocks;

public class StockOperationResultDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool HasWarning { get; set; }

    public string? WarningMessage { get; set; }
}