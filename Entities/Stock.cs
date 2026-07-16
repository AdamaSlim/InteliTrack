namespace InteliTrack.Domain.Entities;

public class Stock
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int ShelfId { get; set; }

    public Shelf Shelf { get; set; } = null!;

    public int Quantity { get; set; }

    public bool IsActive { get; set; } = true;
}