using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IStockRepository
{
    Task<Stock?> GetByIdAsync(int id);
    

    Task<Stock?> GetByProductAndShelfAsync(int productId, int shelfId);
    Task<int> GetTotalQuantityOnShelfAsync(int shelfId);

    Task<IEnumerable<Stock>> GetAllAsync();

    Task AddAsync(Stock stock);

    void Update(Stock stock);
    Task<Stock?> GetByProductAndStoreAsync(
    int productId,
    int storeId);
}