namespace InteliTrack.Application.DTOs.Auth;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public int StoreId { get; set; }
}