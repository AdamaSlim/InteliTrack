using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface IStockMovementRepository
{
    Task AddAsync(StockMovement movement);

    Task<IEnumerable<StockMovement>> GetProductHistoryAsync(int productId);
}