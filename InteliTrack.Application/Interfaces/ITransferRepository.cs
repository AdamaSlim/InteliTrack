using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Interfaces.Repositories;

public interface ITransferRepository 
    : IRepository<Transfer>
{
    Task<Transfer?> GetByIdWithItemsAsync(int id);
}