namespace LetterManagement.Server.Models
{
    public class Department : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
