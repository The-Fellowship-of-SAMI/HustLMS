namespace LetterManagement.Shared.Dtos
{
    public class LetterStateDto
    {
        public Guid? LetterId { get; set; }
        public DateTime? ReceivedDate { get; set; } 

        public Guid? ManagerId { get; set; }

        public string? DepartmentName { get; set; }
        
        
    }
}
