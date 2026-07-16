namespace InteliTrack.Domain.Entities;

public class Shelf
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int SectionId { get; set; }

    public Section Section { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}