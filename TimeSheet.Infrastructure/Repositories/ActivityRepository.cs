using Microsoft.EntityFrameworkCore;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;

namespace TimeSheet.Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly TimeSheetDbContext _context;

    public ActivityRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<Activity?> GetByNameAsync(string name) => await _context.Activity.FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());

    public async Task<int> CountValidIdsAsync(List<Guid> ids) => await _context.Activity.Where(a => ids.Contains(a.Id) && a.IsActive).CountAsync();

    public async Task AddAsync(Activity project) => await _context.Activity.AddAsync(project);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
