namespace TimeSheet.Domain.Entities;

public class ProjectActivity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;
    public bool Active { get; set; } = true;
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}
