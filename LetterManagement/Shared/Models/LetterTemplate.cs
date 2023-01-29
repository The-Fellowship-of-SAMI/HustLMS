namespace LetterManagement.Shared.Models
{
    public class LetterTemplate : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        public string Receiver { get; set; }

        public string? Description { get; set; }

        public string Footer { get; set; }
        public List<TemplateAdditionalField> AdditionalFields { get; set; } = new List<TemplateAdditionalField>();

        public string? Image { get; set; } = null;

        public List<ConfirmationTemplate> ConfirmationsTemplate { get; set; } = new List<ConfirmationTemplate> ();
    }

    public class TemplateAdditionalField
    {
        public Guid Id { get; set; }

        public Guid? GroupFieldId { get; set; }

        public string? FieldName { get; set; } = null;

        public FieldTypes? FieldType { get; set; } = null;

        public string? AdditionalText { get; set; } = null;

    }
    public class ConfirmationTemplate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


    }
    public enum FieldTypes
    {
        Checkbox = 0,
        Text = 1,
        Radio=2,
        Datetime = 3,

    };
}