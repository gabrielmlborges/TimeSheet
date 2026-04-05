using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface ITimeLogService
{
    Task<CreateTimeLogResponseDTO> CreateTimeLog(Guid id, CreateTimeLogRequestDTO dto);
    Task<GetUserLogsResponseDTO> GetUserLogs(Guid userId, GetUserLogsRequestDTO dto);
}
