using InteliTrack.Application.DTOs.Employees;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            StoreId = dto.StoreId,
            RoleId = dto.RoleId,
            IsActive = true
        };

        await _employeeRepository.AddAsync(employee);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(employee);
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        return employee is null
            ? null
            : MapToDto(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        return employees.Select(MapToDto);
    }

    public async Task<EmployeeDto> UpdateAsync(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            throw new Exception("Employee not found.");

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Email = dto.Email;
        employee.StoreId = dto.StoreId;
        employee.RoleId = dto.RoleId;

        _employeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(employee);
    }

    public async Task DeactivateAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            throw new Exception("Employee not found.");

        employee.IsActive = false;

        _employeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync();
    }

    private static EmployeeDto MapToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            StoreId = employee.StoreId,
            RoleId = employee.RoleId,
            IsActive = employee.IsActive
        };
    }
}