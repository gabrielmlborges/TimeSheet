using TimeSheet.Domain.Entities;

namespace TimeSheet.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task<int> CountValidIdsAsync(List<Guid> ids);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
