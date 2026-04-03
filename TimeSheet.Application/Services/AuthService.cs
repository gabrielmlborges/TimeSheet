using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.Enums;
using TimeSheet.Domain.Exceptions;

namespace TimeSheet.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUserRepository userRepository, ITokenService tokenSerivce, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _tokenService = tokenSerivce;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResponseDTO?> RegisterAsync(RegisterRequestDTO dto)
    {
        if (await _userRepository.ExistsByEmailAsync(dto.Email))
        {
            throw new ConflictException("E-mail ja esta cadastrado no sistema");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            PasswordHash = _passwordHasher.Hash(dto.Password),
            Role = UserRole.Normal
        };

        await _userRepository.AddAsync(user);

        await _userRepository.SaveChangesAsync();

        return new RegisterResponseDTO(user.Id, user.Email, user.Role.ToString());
    }

    public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
        {
            throw new InvalidCredentialsException();
        }

        var token = _tokenService.GenerateToken(user);

        return new LoginResponseDTO(user.Id, user.Email, user.Role.ToString(), token);
    }
}
