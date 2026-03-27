using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;

namespace TimeSheet.Infrastructure.Repositories;

public class ActivityRepository 
{
    private readonly TimeSheetDbContext _context;

    public ActivityRepository(TimeSheetDbContext context)
    {
        _context = context;
    }
    public async Task<Activity?> GetTaskAsync(Guid id) => await _context.Activity.FindAsync(id);
    public async Task AddAsync(Activity activity) => await _context.Activity.AddAsync(activity);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}