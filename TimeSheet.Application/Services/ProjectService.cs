using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;

    public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository, IActivityRepository activityRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _activityRepository = activityRepository;
    }

    public async Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto)
    {
        bool projectIsActive = await _projectRepository.IsActive(dto.Name);
        if (projectIsActive)
        {
            throw new InvalidOperationException("Já existe um projeto ativo com esse nome!");
        }

        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            TotalHours = dto.TotalHours
        };

        foreach (Guid a in dto.ActivitiesId)
        {
            bool exists = await _activityRepository.ExistsByIdAsync(a);
            if (!exists)
            {
                throw new InvalidOperationException("Atividade não existe no sistema");
            }
            project.AddActivity(a);
        }

        foreach (Guid u in dto.UsersId)
        {
            bool exists = await _userRepository.ExistsByIdAsync(u);
            if (!exists)
            {
                throw new InvalidOperationException("Usuário não existe no sistema");
            }
            project.AssignUser(u);
        }

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return new CreateProjectResponseDTO(project.Id);
    }
}
