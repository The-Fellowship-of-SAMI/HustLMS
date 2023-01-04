namespace LetterManagement.Server.Dtos;

public class StudentDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? School { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int StudentId { get; set; }

}