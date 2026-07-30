using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;

namespace InteliTrack.Infrastructure.Repos;

public class ProductRepository 
    : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context)
        : base(context)
    {

    }
}