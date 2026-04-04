using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Interfaces;

public interface ITimeLogRepository
{
    Task AddAsync(TimeLog timeLog);
    Task SaveChangesAsync();
}
