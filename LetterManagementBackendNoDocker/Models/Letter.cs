namespace LetterManagementBackendNoDocker.Models
{
    public class Letter
    {
        public Guid Id { get; set; }

        public Guid Template { get; set; }

        public int StudentId { get; set; }

        public int ReceiverId { get; set; }

        public int ResolverId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set;}

        public string State { get; set; }


    }
}
