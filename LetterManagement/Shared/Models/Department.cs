namespace LetterManagement.Shared.Models
{
    public class Department : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public string ShortName { get; set; } = "";
    }
}
