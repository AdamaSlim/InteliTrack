using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class ShelfRepository
    : GenericRepository<Shelf>,
      IShelfRepository
{
    public ShelfRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Shelf?> GetByIdWithSectionAsync(int id)
    {
        return await _context.Shelves
            .Include(s => s.Section)
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
    }

    public async Task<IEnumerable<Shelf>> GetAllWithSectionAsync()
    {
        return await _context.Shelves
            .Include(s => s.Section)
            .Where(s => s.IsActive)
            .ToListAsync();
    }
}