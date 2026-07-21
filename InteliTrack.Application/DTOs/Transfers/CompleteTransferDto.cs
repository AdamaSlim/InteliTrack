namespace InteliTrack.Application.DTOs.Transfers;

public class CompleteTransferDto
{
    public int TransferId { get; set; }

    public int EmployeeId { get; set; }

    public int DestinationShelfId { get; set; }
}