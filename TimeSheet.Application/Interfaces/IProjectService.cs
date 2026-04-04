using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IProjectService
{
    Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto);

    Task AddActivitiesToProject(Guid projectId, AddActivitiesToProjectDTO dto);

    Task AssignUsersToProject(Guid projectId, AssignUsersToProjectDTO dto);
}
