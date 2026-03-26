namespace TimeSheet.Application.DTOs;

public record RegisterResponseDTO(Guid Id, string Email, string Role);
public record LoginResponseDTO(Guid Id, string Email, string Role, string Token);
public record LoginRequestDTO(string Email, string Password);
public record RegisterRequestDTO(string Email, string Password);
