namespace InteliTrack.Application.DTOs.Stocks;

public class RemoveStockDto
{
    public int StockId { get; set; }

    public int Quantity { get; set; }

    public int EmployeeId { get; set; }

    public string? Reason { get; set; }

    
}