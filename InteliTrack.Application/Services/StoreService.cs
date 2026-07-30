using InteliTrack.Application.DTOs.Stores;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StoreService(
        IStoreRepository storeRepository,
        IUnitOfWork unitOfWork)
    {
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<StoreDto> CreateAsync(CreateStoreDto dto)
    {
        var store = new Store
        {
            Name = dto.Name,
            City = dto.City,
            Address = dto.Address,
            Phone = dto.Phone,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await _storeRepository.AddAsync(store);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(store);
    }

    public async Task<StoreDto?> GetByIdAsync(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        return store is null ? null : MapToDto(store);
    }

    public async Task<IEnumerable<StoreDto>> GetAllAsync()
    {
        var stores = await _storeRepository.GetAllAsync();

        return stores.Select(MapToDto);
    }

    public async Task<StoreDto> UpdateAsync(int id, UpdateStoreDto dto)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
            throw new Exception("Store not found.");

        store.Name = dto.Name;
        store.City = dto.City;
        store.Address = dto.Address;
        store.Phone = dto.Phone;

        _storeRepository.Update(store);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(store);
    }

    public async Task DeactivateAsync(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
            throw new Exception("Store not found.");

        store.IsActive = false;

        _storeRepository.Update(store);

        await _unitOfWork.SaveChangesAsync();
    }

    private static StoreDto MapToDto(Store store)
    {
        return new StoreDto
        {
            Id = store.Id,
            Name = store.Name,
            City = store.City,
            Address = store.Address,
            Phone = store.Phone,
            IsActive = store.IsActive
        };
    }
}