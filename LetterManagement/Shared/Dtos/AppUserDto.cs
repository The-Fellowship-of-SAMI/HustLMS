using LetterManagement.Shared.Models;

namespace LetterManagement.Shared.Dtos;

public class AppUserDto
{
    public string Email { get; set; }
    
    public string Token { get; set; }

    public Roles Role { get; set; }

    public Guid UserId { get; set; }
}