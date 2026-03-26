using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IProjectService
{
    Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto);
}
