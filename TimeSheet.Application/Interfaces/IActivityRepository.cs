using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IActivityRepository
{
    Task<Activity?> GetByIdAsync(Guid id);
    Task AddAsync(Activity activity);
    Task SaveChangesAsync();
}