using InteliTrack.Application.DTOs.Products;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Barcode = dto.Barcode,
            CategoryId = dto.CategoryId,
            SupplierId = dto.SupplierId,
            UnitPrice = dto.UnitPrice,
            MinimumStockLevel = dto.MinimumStockLevel,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(product);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        return product is null ? null : MapToDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(MapToDto);
    }

    public async Task<ProductDto> UpdateAsync(
        int id,
        UpdateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found.");

        product.Name = dto.Name;
        product.UnitPrice = dto.UnitPrice;
        product.MinimumStockLevel = dto.MinimumStockLevel;

        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(product);
    }

    public async Task DeactivateAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found.");

        product.IsActive = false;

        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync();
    }

    private static ProductDto MapToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Barcode = product.Barcode,
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId,
            UnitPrice = product.UnitPrice,
            MinimumStockLevel = product.MinimumStockLevel,
            IsActive = product.IsActive
        };
    }
}