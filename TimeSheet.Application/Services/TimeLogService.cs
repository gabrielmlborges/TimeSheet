using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;

namespace TimeSheet.Application.Services;

public class TimeLogService
{
    private readonly ITimeLogRepository _timeLogRepository;

    public TimeLogService(ITimeLogRepository timeLogRepository)
    {
        _timeLogRepository = timeLogRepository;
    }

    // public Task<CreateTimeLogResponseDTO> CreateTimeLog(Guid id, CreateTimeLogRequestDTO dto)
    // {
    // }
}
