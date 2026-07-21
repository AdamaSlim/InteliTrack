using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class StoreRepository : IStoreRepository
{
    private readonly AppDbContext _context;

    public StoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Store?> GetByIdAsync(int id)
    {
        return await _context.Stores
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
    }

    public async Task<IEnumerable<Store>> GetAllAsync()
    {
        return await _context.Stores
            .Where(s => s.IsActive)
            .ToListAsync();
    }
    public async Task<int> GetTotalQuantityOnShelfAsync(int shelfId)
{
    return await _context.Stocks
        .Where(s => s.ShelfId == shelfId && s.IsActive)
        .SumAsync(s => s.Quantity);
}
}