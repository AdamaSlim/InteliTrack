using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class TransferRepository 
    : GenericRepository<Transfer>, ITransferRepository
{
    private readonly AppDbContext _context;

     public TransferRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Transfer?> GetByIdWithItemsAsync(int id)
    {
        return await _context.Transfers
            .Include(t => t.Items)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public void Update(Transfer transfer)
    {
        var entry = _context.Entry(transfer);

        entry.State = EntityState.Unchanged;
        entry.Property(t => t.Status).IsModified = true;

        if (transfer.DeliveredAt.HasValue)
        {
            entry.Property(t => t.DeliveredAt).IsModified = true;
        }

        if (transfer.CompletedAt.HasValue)
        {
            entry.Property(t => t.CompletedAt).IsModified = true;
        }
    }
}