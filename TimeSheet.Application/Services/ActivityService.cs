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
        bool exists = await _activityRepository.ExistsByNameAsync(dto.Name);

        if (exists)
        {
            throw new ConflictException("Ja existe uma atividade cadastrada com esse nome");
        }
        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
        };

        await _activityRepository.AddAsync(activity);
        await _activityRepository.SaveChangesAsync();

        return new CreateActivityResponseDTO(activity.Id);
    }
}
