using InteliTrack.Application.DTOs.Categories;

namespace InteliTrack.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

    Task<CategoryDto?> GetByIdAsync(int id);

    Task<IEnumerable<CategoryDto>> GetAllAsync();

    Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto);

    Task DeactivateAsync(int id);
}