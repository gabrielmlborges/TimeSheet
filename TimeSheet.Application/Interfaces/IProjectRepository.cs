using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
    Task AssignMultipleAsync(Guid projectId, List<Guid> usersIds);
    Task UnassignEmployeeAsync(Guid projectId, Guid userId);
}
