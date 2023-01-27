namespace LetterManagement.Shared.Models;

public class ManagerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";
    public string? Description { get; set; }

    public DateTime DateOfBirth { get; set; }
    
    public string? Email { get; set; } 

    public string PhoneNumber { get; set; } = "";

    public string Department { get; set; } = "";
}