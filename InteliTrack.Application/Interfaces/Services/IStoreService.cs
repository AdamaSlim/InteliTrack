using InteliTrack.Application.DTOs.Stores;

namespace InteliTrack.Application.Interfaces.Services;

public interface IStoreService
{
    Task<StoreDto> CreateAsync(CreateStoreDto dto);

    Task<StoreDto?> GetByIdAsync(int id);

    Task<IEnumerable<StoreDto>> GetAllAsync();

    Task<StoreDto> UpdateAsync(int id, UpdateStoreDto dto);

    Task DeactivateAsync(int id);
}