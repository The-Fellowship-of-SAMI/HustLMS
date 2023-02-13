namespace LetterManagement.Shared.Dtos;

public class UpdateLetterNoteDto
{
    public Guid LetterId { get; set; }
    public string NoteToStudent { get; set; }
}