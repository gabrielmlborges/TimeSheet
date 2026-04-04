using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.Exceptions;

namespace TimeSheet.Application.Services;

public class TimeLogService : ITimeLogService
{
    private readonly ITimeLogRepository _timeLogRepository;
    private readonly IProjectAssignmentRepository _projectAssignmentRepository;
    private readonly IProjectRepository _projectRepository;

    public TimeLogService(ITimeLogRepository timeLogRepository, IProjectAssignmentRepository projectAssignmentRepository, IProjectRepository projectRepository)
    {
        _timeLogRepository = timeLogRepository;
        _projectAssignmentRepository = projectAssignmentRepository;
        _projectRepository = projectRepository;
    }

    public async Task<CreateTimeLogResponseDTO> CreateTimeLog(Guid userId, CreateTimeLogRequestDTO dto)
    {
        ProjectAssignment pa = await _projectAssignmentRepository.GetActiveAssignmentAsync(userId, dto.ProjectId);

        if (pa is null) throw new NotFoundException("Usuario nao esta relacionado a esse projeto");

        bool activityValidation = await _projectRepository.ActivityIsLinkedAsync(dto.ActivityId, dto.ProjectId);

        if (!activityValidation) throw new NotFoundException("Atividade nao relacionada ou nao ativa para esse projeto");

        TimeLog tl = new TimeLog
        {
            ProjectAssignment = pa,
            ProjectId = dto.ProjectId,
            ActivityId = dto.ActivityId,
            Hours = dto.Hours,
            Description = dto.Description,
            DateRef = dto.DateRef
        };

        await _timeLogRepository.AddAsync(tl);
        await _timeLogRepository.SaveChangesAsync();

        return new CreateTimeLogResponseDTO(tl.Id);
    }
}
