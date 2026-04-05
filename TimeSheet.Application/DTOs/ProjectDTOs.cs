using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.DTOs;

public record CreateProjectResponseDTO(Guid Id);
public record CreateProjectRequestDTO(string Name, int TotalHours);
public record AddActivitiesToProjectDTO(List<Guid> ActivitiesId);
public record AssignUsersToProjectDTO(List<Guid> UsersId);
public record GetUserProjectsResponseDTO(List<Project> Projects);
public record GetAllProjectsResponseDTO(List<Project> Projects);
