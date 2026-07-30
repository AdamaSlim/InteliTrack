using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class SectionRepository
    : GenericRepository<Section>,
      ISectionRepository
{
    public SectionRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Section?> GetByIdWithStoreAsync(int id)
    {
        return await _context.Sections
            .Include(s => s.Store)
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
    }

    public async Task<IEnumerable<Section>> GetAllWithStoreAsync()
    {
        return await _context.Sections
            .Include(s => s.Store)
            .Where(s => s.IsActive)
            .ToListAsync();
    }
}