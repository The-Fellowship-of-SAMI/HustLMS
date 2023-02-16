namespace LetterManagement.Shared.Models
{
    public class LetterTemplate : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();
        public string? Receiver { get; set; }

        public string? Description { get; set; }

        public string? Footer { get; set; }
        public List<TemplateAdditionalField> AdditionalFields { get; set; } = new List<TemplateAdditionalField>();

        public List<ConfirmationTemplate> ConfirmationsTemplate { get; set; } = new List<ConfirmationTemplate> ();
    }

    public class TemplateAdditionalField
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? GroupFieldId { get; set; }

        public string? FieldName { get; set; } = "";

        public FieldTypes FieldType { get; set; } = FieldTypes.Text;

        public string? AdditionalText { get; set; } = null;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(GroupFieldId)}: {GroupFieldId}, {nameof(FieldName)}: {FieldName}, {nameof(FieldType)}: {FieldType}, {nameof(AdditionalText)}: {AdditionalText}";
        }
    }
    public class ConfirmationTemplate
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";


    }
    public enum FieldTypes
    {
        Checkbox = 0,
        Text = 1,
        Radio=2,
        Datetime = 3,

    };
}