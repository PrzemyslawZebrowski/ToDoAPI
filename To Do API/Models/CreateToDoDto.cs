namespace ToDoAPI.Models;

public class CreateToDoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Deadline { get; set; }
}