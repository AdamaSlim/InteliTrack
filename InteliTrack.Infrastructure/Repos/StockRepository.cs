using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;

    public StockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks
            .Include(s => s.Product)
            .Include(s => s.Shelf)
                .ThenInclude(sh => sh.Section)
                    .ThenInclude(sec => sec.Store)
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
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
                s.ShelfId == shelfId &&
                s.IsActive);
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
                s.Shelf.Section.StoreId == storeId &&
                s.IsActive);
    }

    public async Task<int> GetTotalQuantityOnShelfAsync(int shelfId)
    {
        return await _context.Stocks
            .Where(s =>
                s.ShelfId == shelfId &&
                s.IsActive)
            .SumAsync(s => s.Quantity);
    }

    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _context.Stocks
            .Where(s => s.IsActive)
            .ToListAsync();
    }

    public async Task AddAsync(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
    }

    public void Update(Stock stock)
    {
        _context.Stocks.Update(stock);
    }
}