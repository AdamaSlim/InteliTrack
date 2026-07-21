using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IStoreRepository
{
    Task<Store?> GetByIdAsync(int id);

    Task<IEnumerable<Store>> GetAllAsync();
}