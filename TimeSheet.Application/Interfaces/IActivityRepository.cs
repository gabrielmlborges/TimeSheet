using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IActivityRepository
{
    Task<Activity?> GetByNameAsync(string name);
    Task<int> CountValidIdsAsync(List<Guid> ids);
    Task AddAsync(Activity activity);
    Task SaveChangesAsync();
}
