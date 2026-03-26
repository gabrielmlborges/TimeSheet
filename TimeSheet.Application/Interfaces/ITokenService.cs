using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
