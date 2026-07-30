namespace InteliTrack.Application.DTOs.Employees;

public class CreateEmployeeDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int StoreId { get; set; }

    public int RoleId { get; set; }
}