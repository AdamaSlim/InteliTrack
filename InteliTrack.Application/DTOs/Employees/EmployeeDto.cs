namespace InteliTrack.Application.DTOs.Employees;

public class EmployeeDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int StoreId { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }
}