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
            .FirstOrDefaultAsync(s => s.Id == id);
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

    public async Task<int> GetTotalQuantityOnShelfAsync(int shelfId)
    {
        return await _context.Stocks
            .Where(s =>
                s.ShelfId == shelfId)
            .SumAsync(s => s.Quantity);
    }

    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _context.Stocks
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