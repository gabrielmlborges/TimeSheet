namespace TimeSheet.Application.DTOs;

public record CreateProjectResponseDTO(Guid Id);
public record CreateProjectRequestDTO(string Name, int TotalHours);
