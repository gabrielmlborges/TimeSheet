using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.DTOs;

public record CreateProjectResponseDTO(Guid Id);
public record CreateProjectRequestDTO(string Name, int TotalHours, List<Guid> UsersId, List<Guid> ActivitiesId);
