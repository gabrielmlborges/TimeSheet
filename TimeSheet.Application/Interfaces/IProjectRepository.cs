using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project?> GetByIdWithDatailsAsync(Guid id);
    Task<bool> IsActive(string name);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
}
