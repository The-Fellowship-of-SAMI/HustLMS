// ReSharper disable CollectionNeverUpdated.Global
namespace LetterManagement.Server.Models
{
    public class Letter : BaseModel
    {
        public Guid Id { get; set; }

        public LetterTemplate? Template { get; set; }

        public Student? Student { get; set; }

        public Manager? Manager { get; set; }

        public string? NoteToStudent { get; set; }
        public DateTime? ReceivedDate { get; set; } = null;

        public DateTime? FinishedDate { get; set; } = null;

        public string State {
            get {
                if(ReceivedDate is not null)
                    return "Received";

                if (FinishedDate is not null)
                    return "Finished";
                else return "Sent";
                } 
        }

        public List<LetterAdditionalField> LetterAdditionalFields { get; set; } = new List<LetterAdditionalField>();
    }
}
