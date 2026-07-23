namespace InteliTrack.Application.DTOs.Transfers;

public class TransferResultDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public int? TransferId { get; set; }

    public TransferDto? Transfer { get; set; }
}