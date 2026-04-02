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

    public void AssignUser(Guid userId)
    {
        if (_assignments.Any(a => a.UserId == userId && a.IsActive)) throw new InvalidOperationException("Usuário já alocado nesse projeto");

        var assignment = new ProjectAssignment 
        {
            ProjectId = this.Id,
            UserId = userId
        };

        _assignments.Add(assignment);
    }

    public void AddActivity(Guid activityId)
    {
        if (_activities.Any(a => a.ActivityId == activityId)) throw new InvalidOperationException("Atividade já registrada");

        var projectActivity = new ProjectActivity
        {
            ProjectId = this.Id,
            ActivityId = activityId
        };

        _activities.Add(projectActivity);
    }
}
