using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.Exceptions;

namespace TimeSheet.Application.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
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
