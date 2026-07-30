using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IShelfRepository
    : IRepository<Shelf>
{
    Task<Shelf?> GetByIdWithSectionAsync(int id);

    Task<IEnumerable<Shelf>> GetAllWithSectionAsync();
}