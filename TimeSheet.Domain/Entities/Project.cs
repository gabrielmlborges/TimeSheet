namespace TimeSheet.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int TotalHours { get; set; }
    public bool IsActive { get; set; } = true;
    private readonly List<ProjectAssignment> _assignments = new();
    public virtual IReadOnlyCollection<ProjectAssignment> Assignments => _assignments.AsReadOnly();
    private readonly List<ProjectActivity> _activities = new();
    public virtual IReadOnlyCollection<ProjectActivity> Activities => _activities.AsReadOnly();

    public void AddActivity(Guid activityId)
    {
        if (_activities.Any(a => a.ActivityId == activityId)) return;

        var projectActivity = new ProjectActivity
        {
            ProjectId = this.Id,
            ActivityId = activityId
        };

        _activities.Add(projectActivity);
    }
}
