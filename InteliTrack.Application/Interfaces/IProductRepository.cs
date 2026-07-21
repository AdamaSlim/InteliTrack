using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllAsync();

    Task AddAsync(Product product);

    void Update(Product product);
}