using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdWithActivitiesAsync(Guid id);
    Task<bool> IsActive(string name);
    Task<bool> ExistsAndActive(Guid id);
    Task<bool> ActivityIsLinkedAsync(Guid activityId, Guid projectId);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
}
