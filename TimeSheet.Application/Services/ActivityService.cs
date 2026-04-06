using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.Interfaces;

namespace TimeSheet.Application.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectAssignmentRepository _projectAssignmentRepository;

    public ActivityService(IActivityRepository activityRepository, IProjectRepository projectRepository, IProjectAssignmentRepository projectAssignmentRepository)
    {
        _activityRepository = activityRepository;
        _projectRepository = projectRepository;
        _projectAssignmentRepository = projectAssignmentRepository;
    }

    public async Task<GetAllActivitiesResponseDTO> GetAllActivities() => new GetAllActivitiesResponseDTO(await _activityRepository.GetActivitiesAsync());

    public async Task<GetProjectActivitiesResponseDTO> GetProjectActivities(Guid projectId, Guid userId)
    {
        var isMember = await _projectAssignmentRepository.IsUserMember(projectId, userId);

        if (!isMember)
        {
            throw new UnauthorizedAccessException("Usuário não tem permissão para ver este projeto.");
        }

        return new GetProjectActivitiesResponseDTO(await _projectRepository.GetProjectActivities(projectId));
    }

    public async Task<CreateActivityResponseDTO> CreateActivity(CreateActivityRequestDTO dto)
    {
        var activity = await _activityRepository.GetByNameAsync(dto.Name);

        if (activity != null)
        {
            if (!activity.IsActive)
            {
                activity.IsActive = true;
                await _activityRepository.SaveChangesAsync();
            }

            return new CreateActivityResponseDTO(activity.Id);
        }

        var newActivity = new Activity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
        };

        await _activityRepository.AddAsync(newActivity);
        await _activityRepository.SaveChangesAsync();

        return new CreateActivityResponseDTO(newActivity.Id);
    }
}
