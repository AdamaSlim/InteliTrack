namespace InteliTrack.Application.DTOs.Products;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public decimal UnitPrice { get; set; }

    public int MinimumStockLevel { get; set; }
}