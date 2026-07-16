namespace InteliTrack.Domain.Entities;

public class Transfer
{
    public int Id { get; set; }

    public int SourceStoreId { get; set; }

    public Store SourceStore { get; set; } = null!;

    public int DestinationStoreId { get; set; }

    public Store DestinationStore { get; set; } = null!;

    public string Status { get; set; } = "IN_TRANSIT";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TransferItem> Items { get; set; } = new List<TransferItem>();
}