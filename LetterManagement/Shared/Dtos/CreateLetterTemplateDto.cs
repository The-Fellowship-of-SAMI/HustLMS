using LetterManagement.Shared.Models;

namespace LetterManagement.Shared.Dtos;

public class CreateLetterTemplateDto : BaseModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public List<string> DepartmentIds { get; set; } = new List<string>();
    
    public string? Receiver { get; set; }

    public string? Description { get; set; }

    public string? Footer { get; set; }
    public List<TemplateAdditionalField> AdditionalFields { get; set; } = new List<TemplateAdditionalField>();

    public List<ConfirmationTemplate>? ConfirmationsTemplate { get; set; } = new List<ConfirmationTemplate> ();
}