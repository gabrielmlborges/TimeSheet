using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IActivityService
{
    Task<CreateActivityResponseDTO> CreateActivity(CreateActivityRequestDTO dto);
    Task<GetAllActivitiesResponseDTO> GetAllActivities();
    Task<GetProjectActivitiesResponseDTO> GetProjectActivities(Guid projectId, Guid userId);
}
