using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.DTOs;

public record CreateActivityResponseDTO(Guid Id);
public record CreateActivityRequestDTO(string Name);
public record GetAllActivitiesResponseDTO(List<Activity> Activities);
public record GetProjectActivitiesResponseDTO(List<Activity> Activities);
