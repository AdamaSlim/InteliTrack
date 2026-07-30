using InteliTrack.Application.DTOs.Employees;

namespace InteliTrack.Application.Interfaces.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);

    Task<EmployeeDto?> GetByIdAsync(int id);

    Task<IEnumerable<EmployeeDto>> GetAllAsync();

    Task<EmployeeDto> UpdateAsync(int id, UpdateEmployeeDto dto);

    Task DeactivateAsync(int id);
}