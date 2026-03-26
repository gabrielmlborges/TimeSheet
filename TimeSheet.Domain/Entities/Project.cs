namespace TimeSheet.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int TotalHours { get; set; }
    private readonly List<ProjectAssignment> _assignments = new();
    public virtual IReadOnlyCollection<ProjectAssignment> Assignments => _assignments.AsReadOnly();
    private readonly List<ProjectActivity> _activities = new();
    public virtual IReadOnlyCollection<ProjectActivity> Activities => _activities.AsReadOnly();

    public void AssignUser(User user)
    {
        if (_assignments.Any(a => a.UserId == user.Id && a.IsActive)) throw new InvalidOperationException("Usuário já alocado nesse projeto");

        var assignment = new ProjectAssignment 
        {
            User = user,
            Project = this,
            ProjectId = this.Id,
            UserId = user.Id
        };

        _assignments.Add(assignment);
    }

    public void AddActivity(Activity activity)
    {
        if (_activities.Any(a => a.ActivityId == activity.Id)) throw new InvalidOperationException("Atividade já registrada");

        var projectActivity = new ProjectActivity
        {
            Activity = activity,
            Project = this,
            ProjectId = this.Id,
            ActivityId = activity.Id
        };

        _activities.Add(projectActivity);
    }
}
