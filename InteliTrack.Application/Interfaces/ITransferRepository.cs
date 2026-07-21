using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface ITransferRepository
{
    Task<Transfer?> GetByIdAsync(int id);

    Task<IEnumerable<Transfer>> GetAllAsync();
    Task<Transfer?> GetByIdWithItemsAsync(int id);

    Task AddAsync(Transfer transfer);

    void Update(Transfer transfer);
}