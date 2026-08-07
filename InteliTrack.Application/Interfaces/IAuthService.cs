using InteliTrack.Application.DTOs.Auth;

namespace InteliTrack.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
}