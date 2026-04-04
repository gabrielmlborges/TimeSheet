namespace TimeSheet.Domain.Entities;

public class Activity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual ICollection<ProjectActivity> ProjectActivities { get; set; } = new List<ProjectActivity>();
}
