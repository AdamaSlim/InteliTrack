using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class StockRepository 
    : GenericRepository<Stock>, IStockRepository
{
    public StockRepository(AppDbContext context)
        : base(context)
    {
    }


    public async Task<Stock?> GetByProductAndShelfAsync(
        int productId,
        int shelfId)
    {
        return await _context.Stocks
            .Include(s => s.Product)
            .Include(s => s.Shelf)
                .ThenInclude(sh => sh.Section)
            .FirstOrDefaultAsync(s =>
                s.ProductId == productId &&
                s.ShelfId == shelfId);
    }


    public async Task<Stock?> GetByProductAndStoreAsync(
        int productId,
        int storeId)
    {
        return await _context.Stocks
            .Include(s => s.Product)
            .Include(s => s.Shelf)
                .ThenInclude(sh => sh.Section)
            .FirstOrDefaultAsync(s =>
                s.ProductId == productId &&
                s.Shelf.Section.StoreId == storeId);
    }


    public async Task<int> GetTotalQuantityOnShelfAsync(
        int shelfId)
    {
        return await _context.Stocks
            .Where(s => s.ShelfId == shelfId)
            .SumAsync(s => s.Quantity);
    }
}