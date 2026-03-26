namespace TimeSheet.Domain.Entities;

public class ProjectAssignment
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }
    public required Project Project { get; set; }

    public Guid UserId { get; set; }
    public required User User { get; set; }

    public DateTime StartDate = DateTime.UtcNow;
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; } = true;

    private readonly List<TimeLog> _timeLogs = new();
    public virtual IReadOnlyCollection<TimeLog> TimeLogs => _timeLogs.AsReadOnly();
}
