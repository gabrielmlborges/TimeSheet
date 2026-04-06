using TimeSheet.Domain.Entities;

namespace TimeSheet.Domain.Interfaces;

public interface ITimeLogRepository
{
    Task<List<TimeLog>> GetUserLogs(Guid userId, DateOnly startDate, DateOnly endDate);
    Task AddAsync(TimeLog timeLog);
    Task SaveChangesAsync();
}
