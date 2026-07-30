using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface ISectionRepository
    : IRepository<Section>
{
    Task<Section?> GetByIdWithStoreAsync(int id);

    Task<IEnumerable<Section>> GetAllWithStoreAsync();
}