using LetterManagement.Shared.Models;

namespace LetterManagement.Server.Dtos;

public class CreateLetterDto
{
    public Guid Id { get; set; }

    public string? LetterTemplateId { get; set; }

    public int? StudentId { get; set; }
    
    public List<LetterAdditionalField> LetterAdditionalFields { get; set; } = new List<LetterAdditionalField>();

    public List<Confirmation> Confirmations { get; set; } = new List<Confirmation>();
}