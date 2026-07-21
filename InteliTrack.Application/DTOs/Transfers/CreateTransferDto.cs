namespace InteliTrack.Application.DTOs.Transfers;

public class CreateTransferDto
{
    public int SourceStoreId { get; set; }

    public int DestinationStoreId { get; set; }

    public int EmployeeId { get; set; }

    public List<TransferItemDto> Items { get; set; } = [];
}