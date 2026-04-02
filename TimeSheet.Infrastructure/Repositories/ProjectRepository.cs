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

    public async Task<Project?> GetByIdAsync(Guid id) => await _context.Projects.FindAsync(id);

    public async Task<Project?> GetByIdWithDatailsAsync(Guid id) {
        return await _context.Projects
            .Include(p => p.Activities)
                .ThenInclude(pa => pa.Activity)
            .Include(p => p.Assignments)
                .ThenInclude(pa => pa.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> IsActive(string name) => await _context.Projects.AnyAsync(p => p.Name == name && p.IsActive);

    public async Task AddAsync(Project project) => await _context.Projects.AddAsync(project);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
