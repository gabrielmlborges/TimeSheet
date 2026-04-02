using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IActivityRepository
{
    Task<Activity?> GetByIdAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByIdAsync(Guid id);
    Task AddAsync(Activity activity);
    Task SaveChangesAsync();
}
