namespace LetterManagement.Server.Services;

public interface ICrud<TDto>
{
    Task<IEnumerable<TDto>> GetAll();

    Task<TDto> Create(TDto tDto);

    Task<TDto> Update(Guid id, TDto tNew);

    Task<TDto> Delete(TDto t);
}