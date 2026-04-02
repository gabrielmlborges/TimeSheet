namespace TimeSheet.Domain.Entities;

public class ProjectAssignment
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime StartDate = DateTime.UtcNow;
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; } = true;

    private readonly List<TimeLog> _timeLogs = new();
    public virtual IReadOnlyCollection<TimeLog> TimeLogs => _timeLogs.AsReadOnly();
}
