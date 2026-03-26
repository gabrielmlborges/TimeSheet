namespace TimeSheet.Application.DTOs;

public record CreateProjectResponseDTO(Guid Id, string Name);
public record UnassignEmployeesResponseDTO(Guid ProjectId, Guid EmployeesId);
public record CreateProjectRequestDTO(string Name, int TotalHours);
public record AssignEmployeesRequestDTO(Guid ProjectId, List<Guid> UsersIds);
public record UnassignEmployeesRequestDTO(Guid ProjectId, Guid UserId);
