namespace LetterManagement.Shared.Dtos
{
    public class LetterStateDto
    {
        public Guid LetterId { get; set; }
        public DateTime? ReceivedDate { get; set; } 

        public DateTime? FinishedDate { get; set; } 
    }
}
