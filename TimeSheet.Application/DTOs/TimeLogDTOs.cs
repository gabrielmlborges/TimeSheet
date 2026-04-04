namespace TimeSheet.Application.DTOs;

public record CreateTimeLogRequestDTO(Guid ProjectId, Guid ActivityId, Decimal Hours, string Description, DateTime DateRef);

public record CreateTimeLogResponseDTO(Guid TimeLogId);
