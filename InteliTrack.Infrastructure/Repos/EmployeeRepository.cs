using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class EmployeeRepository
    : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Employee?> GetByIdWithStoreAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Store)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
    }

    public async Task<IEnumerable<Employee>> GetAllWithDetailsAsync()
    {
        return await _context.Employees
            .Include(e => e.Store)
            .Include(e => e.Role)
            .Where(e => e.IsActive)
            .ToListAsync();
    }
}