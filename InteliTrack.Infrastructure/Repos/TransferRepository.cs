using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class TransferRepository : ITransferRepository
{
    private readonly AppDbContext _context;

    public TransferRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Transfer?> GetByIdAsync(int id)
    {
        return await _context.Transfers
            .FirstOrDefaultAsync(t => t.Id == id);
    }


    public async Task<Transfer?> GetByIdWithItemsAsync(int id)
    {
        return await _context.Transfers
            .Include(t => t.Items)
            .FirstOrDefaultAsync(t => t.Id == id);
    }


    public async Task<IEnumerable<Transfer>> GetAllAsync()
    {
        return await _context.Transfers
            .Include(t => t.Items)
            .ToListAsync();
    }


    public async Task AddAsync(Transfer transfer)
    {
        await _context.Transfers.AddAsync(transfer);
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