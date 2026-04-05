using Microsoft.EntityFrameworkCore;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;

namespace TimeSheet.Infrastructure.Repositories;

public class TimeLogRepository : ITimeLogRepository
{
    private readonly TimeSheetDbContext _timeSheetDbContext;

    public TimeLogRepository(TimeSheetDbContext timeSheetDbContext)
    {
        _timeSheetDbContext = timeSheetDbContext;
    }

    public async Task<List<TimeLog>> GetUserLogs(Guid userId, DateOnly startDate, DateOnly endDate)
    {
        return await _timeSheetDbContext.TimeLog
            .Include(tl => tl.ProjectActivity)
                .ThenInclude(pa => pa.Activity)
            .Include(tl => tl.ProjectAssignment)
                .ThenInclude(pa => pa.Project)
            .Where(tl => tl.ProjectAssignment.UserId == userId
                    && tl.DateRef >= startDate
                    && tl.DateRef <= endDate)
            .OrderByDescending(tl => tl.DateRef)
            .ToListAsync();
    }

    public async Task AddAsync(TimeLog timeLog) => await _timeSheetDbContext.AddAsync(timeLog);

    public async Task SaveChangesAsync() => await _timeSheetDbContext.SaveChangesAsync();
}
