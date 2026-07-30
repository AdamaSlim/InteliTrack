using InteliTrack.Application.DTOs.Products;


namespace InteliTrack.Application.Interfaces.Services;

public interface IProductService
{
    Task<ProductDto> CreateAsync(CreateProductDto dto);

    Task<ProductDto?> GetByIdAsync(int id);

    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto);

    Task DeactivateAsync(int id);
}