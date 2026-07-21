using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Domain.Entities;
using InteliTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InteliTrack.Infrastructure.Repos;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(int id)
{
    var employee = await _context.Employees
        .Include(e => e.Store)
        .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

    Console.WriteLine($"Employee found : {employee?.FirstName}");

    return employee;
}
}