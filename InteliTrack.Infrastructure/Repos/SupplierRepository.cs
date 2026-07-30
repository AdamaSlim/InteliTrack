using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;

namespace InteliTrack.Infrastructure.Repos;

public class SupplierRepository
    : GenericRepository<Supplier>,
      ISupplierRepository
{
    public SupplierRepository(AppDbContext context)
        : base(context)
    {
    }
}