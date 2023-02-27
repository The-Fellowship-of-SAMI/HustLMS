using System.ComponentModel.DataAnnotations;

namespace LetterManagement.Shared.Models
{
    public class Manager
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress] public string? Email { get; set; } 

        public string PhoneNumber { get; set; } = "";

        public Department? Department { get; set; }

        public List<Letter> Letters { get; set; } = new List<Letter>();

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(Email)}: {Email}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Department)}: {Department}";
        }
    }
}
