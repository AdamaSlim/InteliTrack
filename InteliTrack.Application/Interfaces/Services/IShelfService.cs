using InteliTrack.Application.DTOs.Shelves;

namespace InteliTrack.Application.Interfaces.Services;

public interface IShelfService
{
    Task<ShelfDto> CreateAsync(CreateShelfDto dto);

    Task<ShelfDto?> GetByIdAsync(int id);

    Task<IEnumerable<ShelfDto>> GetAllAsync();

    Task<ShelfDto> UpdateAsync(int id, UpdateShelfDto dto);

    Task DeactivateAsync(int id);
}