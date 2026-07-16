namespace InteliTrack.Domain.Entities;

public class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}