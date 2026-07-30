using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;

namespace InteliTrack.Infrastructure.Repos;

public class CategoryRepository
    : GenericRepository<Category>,
      ICategoryRepository
{
    public CategoryRepository(AppDbContext context)
        : base(context)
    {
    }
}