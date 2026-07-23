using InteliTrack.Domain.Enums;

namespace InteliTrack.Application.DTOs.Transfers;

public class TransferDto
{
    public int Id { get; set; }

    public int SourceStoreId { get; set; }

    public int DestinationStoreId { get; set; }

    public int RequestedByEmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public TransferStatus Status { get; set; }

    public List<TransferItemDto> Items { get; set; } = new();
}
