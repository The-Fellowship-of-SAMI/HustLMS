using System.ComponentModel.DataAnnotations;

namespace LetterManagement.Shared.Models
{
    public class Student : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int StudentId { get; set;}

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Department School { get; set; }

        public string SchoolYear { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public DateTime LastLogin { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(StudentId)}: {StudentId}, {nameof(Email)}: {Email}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(School)}: {School}, {nameof(SchoolYear)}: {SchoolYear}, {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(LastLogin)}: {LastLogin}";
        }
    }
}
