using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            TotalHours = dto.TotalHours
        };

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return new CreateProjectResponseDTO(project.Id, project.Name);
    }

    public async Task AssignMultiple(Guid id, AssignEmployeesRequestDTO dto)
    {
        await _projectRepository.AssignMultipleAsync(id, dto.UsersIds);
        await _projectRepository.SaveChangesAsync();
    }

    public async Task UnassignEmployee(UnassignEmployeesRequestDTO dto)
    {
        await _projectRepository.UnassignEmployeeAsync(dto.ProjectId, dto.UserId);
        await _projectRepository.SaveChangesAsync();
    }
}
