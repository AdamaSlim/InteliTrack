using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class StockMovementRepository
    : GenericRepository<StockMovement>,
      IStockMovementRepository
{
    public StockMovementRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<StockMovement>> GetProductHistoryAsync(int productId)
    {
        return await _context.StockMovements
            .Where(m => m.ProductId == productId)
            .OrderByDescending(m => m.MovementDate)
            .ToListAsync();
    }
}