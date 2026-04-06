using TimeSheet.Domain.Entities;

namespace TimeSheet.Domain.Interfaces;

public interface IProjectAssignmentRepository
{
    Task<ProjectAssignment> GetActiveAssignmentAsync(Guid userId, Guid projectId);
    Task<List<Project>> GetUserProjects(Guid userId);
    Task<List<Guid>> VerifyAssignedUsers(Guid projectId, List<Guid> usersId);
    Task<bool> IsUserMember(Guid projectId, Guid userId);
    Task AddAsync(ProjectAssignment projectAssignment);
    Task SaveChangesAsync();
}
