using TimeSheet.Domain.Entities;

namespace TimeSheet.Domain.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdWithActivitiesAsync(Guid id);
    Task<List<Activity>> GetProjectActivities(Guid projectId);
    Task<List<Project>> GetAllProjects();
    Task<bool> IsActive(string name);
    Task<bool> ExistsAndActive(Guid id);
    Task<bool> ActivityIsLinkedAsync(Guid activityId, Guid projectId);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
}
