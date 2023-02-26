namespace LetterManagement.Server.Models;

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Title { get; set; }
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}