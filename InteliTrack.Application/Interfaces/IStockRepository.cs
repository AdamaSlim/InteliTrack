using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IStockRepository : IRepository<Stock>
{
    Task<Stock?> GetByProductAndShelfAsync(
        int productId,
        int shelfId);

    Task<int> GetTotalQuantityOnShelfAsync(
        int shelfId);

    Task<Stock?> GetByProductAndStoreAsync(
        int productId,
        int storeId);
}