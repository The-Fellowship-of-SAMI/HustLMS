using System.Diagnostics.CodeAnalysis;

namespace LetterManagementBackendNoDocker.Models
{
    public class LetterTemplate : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        public string Receiver { get; set; }

        public string Description { get; set; }

        public string Footer { get; set; }
        public List<TemplateAdditionalField> AdditionalFields { get; set; } = new List<TemplateAdditionalField>();
    }

    public class TemplateAdditionalField
    {
        public Guid Id { get; set; }

        public TemplateAdditionalField? GroupAdditionalField { get; set; } = null;

        public string? FieldName { get; set; } = null;

        public string? FieldType { get; set; } = null;

    }
}