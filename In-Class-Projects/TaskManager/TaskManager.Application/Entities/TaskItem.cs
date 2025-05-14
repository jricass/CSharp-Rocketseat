using TaskManager.Communication.Enums;

namespace TaskManager.Application.Entities;
public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime DateLimit { get; set; }
}
