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

    public async Task AddAsync(Project project) => await _context.Projects.AddAsync(project);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
