using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IAuthService
{
    Task<RegisterResponseDTO?> RegisterAsync(RegisterRequestDTO dto);
    Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO dto);
}
