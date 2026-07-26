using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(int id);

    Task<IEnumerable<Supplier>> GetAllAsync();

    Task AddAsync(Supplier supplier);

    void Update(Supplier supplier);
}