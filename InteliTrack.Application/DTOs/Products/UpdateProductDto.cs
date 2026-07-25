namespace InteliTrack.Application.DTOs.Products;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int MinimumStockLevel { get; set; }
}