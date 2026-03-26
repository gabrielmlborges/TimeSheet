using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task AssignMultipleAsync(Guid projectId, List<Guid> usersIds)
    {
    }

    public async Task UnassignEmployeeAsync(Guid projectId, Guid userId)
    {
    }
}
