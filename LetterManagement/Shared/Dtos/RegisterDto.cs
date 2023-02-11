using LetterManagement.Shared.Models;

namespace LetterManagement.Shared.Dtos;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public Roles Roles { get; set; }

    public Manager? Manager { get; set; }

    public Student? Student { get; set; }
}