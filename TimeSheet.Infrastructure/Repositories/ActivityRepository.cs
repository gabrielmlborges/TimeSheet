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

    public async Task<Activity?> GetByIdAsync(Guid id) => await _context.Activity.FindAsync(id);

    public async Task<bool> ExistsByNameAsync(string name) => await _context.Activity.AnyAsync(a => a.Name.ToLower() == name.ToLower());

    public async Task<bool> ExistsByIdAsync(Guid id) => await _context.Activity.AnyAsync(a => a.Id == id);

    public async Task AddAsync(Activity project) => await _context.Activity.AddAsync(project);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
