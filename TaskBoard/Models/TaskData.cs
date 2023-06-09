namespace TaskBoard.Models;

public class TaskData
{
    public Guid Id { get; set; }
    public TaskProgress Progress { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime ToBeDone { get; set; }
}