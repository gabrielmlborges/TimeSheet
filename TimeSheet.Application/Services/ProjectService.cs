using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Domain.Interfaces;

namespace TimeSheet.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;
    private readonly IProjectAssignmentRepository _projectAssignmentRepository;

    public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository, IActivityRepository activityRepository, IProjectAssignmentRepository projectAssignmentRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _activityRepository = activityRepository;
        _projectAssignmentRepository = projectAssignmentRepository;
    }

    public async Task<GetAllProjectsResponseDTO> GetAllProjects() => new GetAllProjectsResponseDTO(await _projectRepository.GetAllProjects());

    public async Task<GetUserProjectsResponseDTO> GetUserProjects(Guid userId)
    {
        return new GetUserProjectsResponseDTO(await _projectAssignmentRepository.GetUserProjects(userId));
    }

    public async Task<CreateProjectResponseDTO> CreateProject(CreateProjectRequestDTO dto)
    {
        bool projectIsActive = await _projectRepository.IsActive(dto.Name);
        if (projectIsActive)
        {
            throw new ConflictException("Ja existe um projeto ativo com esse nome");
        }

        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            TotalHours = dto.TotalHours
        };

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return new CreateProjectResponseDTO(project.Id);
    }

    public async Task AddActivitiesToProject(Guid projectId, AddActivitiesToProjectDTO dto)
    {

        var project = await _projectRepository.GetByIdWithActivitiesAsync(projectId);

        if (project == null || !project.IsActive) throw new NotFoundException("Projeto nao encontrado ou inativo.");

        var validActivitiesCount = await _activityRepository.CountValidIdsAsync(dto.ActivitiesId);

        if (validActivitiesCount != dto.ActivitiesId.Count) throw new NotFoundException("Uma ou mais atividades nao existem no sistema");


        foreach (Guid activityId in dto.ActivitiesId)
        {
            project.AddActivity(activityId);
        }

        await _projectRepository.SaveChangesAsync();
    }

    public async Task AssignUsersToProject(Guid projectId, AssignUsersToProjectDTO dto)
    {
        var exists = await _projectRepository.ExistsAndActive(projectId);
        if (!exists) throw new NotFoundException("Projeto nao encontrado ou inativo.");

        var validUsersCount = await _userRepository.CountValidIdsAsync(dto.UsersId);
        if (validUsersCount != dto.UsersId.Count) throw new NotFoundException("Um ou mais usuarios nao existem ou estao inativos no sistema");

        var alreadyAssignedIds = await _projectAssignmentRepository.VerifyAssignedUsers(projectId, dto.UsersId);
        var newUsersToAssign = dto.UsersId.Except(alreadyAssignedIds).ToList();

        foreach (var userId in newUsersToAssign)
        {
            var assignment = new ProjectAssignment
            {
                ProjectId = projectId,
                UserId = userId,
                IsActive = true
            };

            await _projectAssignmentRepository.AddAsync(assignment);
        }

        await _projectAssignmentRepository.SaveChangesAsync();
    }
}
