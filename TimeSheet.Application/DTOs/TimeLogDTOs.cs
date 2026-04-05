using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.DTOs;

public record CreateTimeLogRequestDTO(Guid ProjectId, Guid ActivityId, Decimal Hours, string Description, DateOnly DateRef);
public record CreateTimeLogResponseDTO(Guid TimeLogId);
public record GetUserLogsRequestDTO(DateOnly StartDate, DateOnly EndDate);
public record GetUserLogsResponseDTO(List<TimeLog> Logs);
