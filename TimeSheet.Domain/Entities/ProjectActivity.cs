namespace TimeSheet.Domain.Entities;

public class ProjectActivity
{
    public Guid ProjectId { get; set; }
    public required Project Project { get; set; }
    public Guid ActivityId { get; set; }
    public required Activity Activity { get; set; }
    public bool Active { get; set; } = true;
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}
