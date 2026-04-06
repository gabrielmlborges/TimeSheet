using TimeSheet.Domain.Entities;

namespace TimeSheet.Domain.Interfaces;

public interface IActivityRepository
{
    Task<List<Activity>> GetActivitiesAsync();
    Task<Activity?> GetByNameAsync(string name);
    Task<int> CountValidIdsAsync(List<Guid> ids);
    Task AddAsync(Activity activity);
    Task SaveChangesAsync();
}
