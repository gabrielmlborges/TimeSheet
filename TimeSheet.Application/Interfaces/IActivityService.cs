using TimeSheet.Application.DTOs;

namespace TimeSheet.Application.Interfaces;

public interface IActivityService
{
    Task<CreateActivityResponseDTO> CreateActivity(CreateActivityRequestDTO dto);
}