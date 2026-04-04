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

    public async Task AddAsync(TimeLog timeLog) => await _timeSheetDbContext.AddAsync(timeLog);

    public async Task SaveChangesAsync() => await _timeSheetDbContext.SaveChangesAsync();
}
