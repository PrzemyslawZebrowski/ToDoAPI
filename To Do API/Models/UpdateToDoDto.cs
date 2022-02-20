namespace ToDoAPI.Models;

public class UpdateToDoDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? IsCompleted { get; set; }
    public DateTime? Deadline { get; set; }
}