namespace TimeSheet.Domain.Entities;

public class TimeLog
{
    public Guid Id { get; set; }

    public Guid ProjectAssignmentId { get; set; }
    public required ProjectAssignment ProjectAssignment { get; set; }

    public required Guid ProjectId { get; set; }
    public required Guid ActivityId { get; set; }
    public ProjectActivity ProjectActivity { get; set; } = null!;

    public required decimal Hours { get; set; }
    public required string Description { get; set; }
    public required DateOnly DateRef { get; set; }
    public DateTime CreatedAt = DateTime.UtcNow;
}
