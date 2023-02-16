// ReSharper disable CollectionNeverUpdated.Global
namespace LetterManagement.Shared.Models
{
    public class Letter : BaseModel
    {
        public Guid Id { get; set; }

        public LetterTemplate? Template { get; set; }

        public Student? Student { get; set; }

        public List<Manager> Managers { get; set; } = new List<Manager>();

        public string? NoteToStudent { get; set; }
        public DateTime? ReceivedDate { get; set; } = null;

        public DateTime? FinishedDate { get; set; } = null;

        public string State {
            get
            {
                if (FinishedDate.HasValue)
                {
                    return "Hoàn thành";
                }

                if (ReceivedDate.HasValue)
                {
                    return "Đã nhận";
                }

                return "Đã gửi";
            } 
        }

        public List<LetterAdditionalField> LetterAdditionalFields { get; set; } = new List<LetterAdditionalField>();

        public List<Confirmation> Confirmations { get; set; } = new List<Confirmation>();
    }

    public class Confirmation : ConfirmationTemplate
    {
        public string? Note { get; set; }
        public bool? IsOk { get; set; } = false;

        public DateTime? ActionDate { get; set; } = DateTime.MinValue;

        public Department? DepartmentNeedToConfirm { get; set; }
    }
    public class LetterAdditionalField
    {
        public Guid LetterAdditionalFieldId { get; set; } = new Guid();
        public Guid LetterTemplateAdditionalFieldId { get; set; }
        public string? FieldValueString { get; set; }
        public bool FieldValueBool { get; set; } = false;
        public DateTime? FieldValueDateTime { get; set; }
    }
}
