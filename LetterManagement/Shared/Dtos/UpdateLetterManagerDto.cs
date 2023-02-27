using LetterManagement.Shared.Models;

namespace LetterManagement.Shared.Dtos;

public class UpdateLetterManagerDto
{
    public Guid? LetterId { get; set; }

    public List<Guid>? ManagerId { get; set; }
    
    public Guid DepartmentId { get; set; }
}