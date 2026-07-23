namespace InteliTrack.Domain.Entities;
using InteliTrack.Domain.Enums;

public class StockMovement
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;

    public int Quantity { get; set; }

    public MovementType MovementType { get; set; }

    public DateTime MovementDate { get; set; } = DateTime.UtcNow;

    public string? Reason { get; set; }
}