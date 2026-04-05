using Microsoft.EntityFrameworkCore;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;

namespace TimeSheet.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TimeSheetDbContext _context;

    public ProjectRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjects()
    {

        return await _context.Projects.ToListAsync();
    }

    public async Task<List<Activity>> GetProjectActivities(Guid projectId)
    {
        return await _context.ProjectActivity
            .Include(pa => pa.Activity)
            .Where(pa => pa.ProjectId == projectId)
            .Select(pa => pa.Activity)
            .ToListAsync();
    }

    public async Task<Project?> GetByIdWithActivitiesAsync(Guid id) => await _context.Projects.Include(p => p.Activities).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<bool> ExistsAndActive(Guid id) => await _context.Projects.Where(p => p.IsActive).AnyAsync(p => p.Id == id);

    public async Task<bool> IsActive(string name) => await _context.Projects.AnyAsync(p => p.Name == name && p.IsActive);

    public async Task<bool> ActivityIsLinkedAsync(Guid activityId, Guid projectId) => await _context.ProjectActivity.AnyAsync(pa => pa.ActivityId == activityId && pa.ProjectId == projectId && pa.Active);

    public async Task AddAsync(Project project) => await _context.Projects.AddAsync(project);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
