using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class StoreRepository
    : GenericRepository<Store>,
      IStoreRepository
{
    public StoreRepository(AppDbContext context)
        : base(context)
    {
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

    public async Task AddAsync(Store store)
    {
        await _context.Stores.AddAsync(store);
    }

    public void Update(Store store)
    {
        _context.Stores.Update(store);
    }
}
