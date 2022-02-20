namespace ToDoAPI.Models;

public class ToDoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime? Deadline { get; set; }
}