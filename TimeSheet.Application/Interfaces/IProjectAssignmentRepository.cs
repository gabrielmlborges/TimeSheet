using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface IProjectAssignmentRepository
{
    Task<ProjectAssignment> GetActiveAssignmentAsync(Guid userId, Guid projectId);
    Task<List<Guid>> VerifyAssignedUsers(Guid projectId, List<Guid> usersId);
    Task AddAsync(ProjectAssignment projectAssignment);
    Task SaveChangesAsync();
}
