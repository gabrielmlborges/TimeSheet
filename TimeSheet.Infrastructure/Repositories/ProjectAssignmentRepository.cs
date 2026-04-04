using Microsoft.EntityFrameworkCore;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;

namespace TimeSheet.Infrastructure.Repositories;

public class ProjectAssignmentRepository : IProjectAssignmentRepository
{
    private readonly TimeSheetDbContext _context;

    public ProjectAssignmentRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectAssignment?> GetActiveAssignmentAsync(Guid userId, Guid projectId) => await _context.ProjectAssignment.FirstOrDefaultAsync(pa => pa.UserId == userId && pa.ProjectId == projectId && pa.IsActive);

    public async Task<List<Guid>> VerifyAssignedUsers(Guid projectId, List<Guid> usersId)
    {
        return await _context.ProjectAssignment
            .Where(pa => pa.ProjectId == projectId
                    && usersId.Contains(pa.UserId)
                    && pa.IsActive)
            .Select(pa => pa.UserId)
            .ToListAsync();
    }

    public async Task AddAsync(ProjectAssignment pa) => await _context.AddAsync(pa);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
