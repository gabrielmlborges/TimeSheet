using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IProjectService
{
    Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto);
    Task AssignMultiple(Guid id, AssignEmployeesRequestDTO dto);
    Task UnassignEmployee(UnassignEmployeesRequestDTO dto);
}
