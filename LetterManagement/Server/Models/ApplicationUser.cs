
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Identity;
namespace LetterManagement.Server.Models

{
    public class ApplicationUser : IdentityUser
    {
        public Roles Role { get; set; }
        
        public Guid UserId { get; set; }
    }
    
}

