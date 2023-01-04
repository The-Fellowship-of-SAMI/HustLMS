namespace LetterManagement.Server.Services;

public interface ICrud<TDto>
{
    Task<IEnumerable<TDto>> getAll();

    Task<TDto> create(TDto tDto);

    Task<TDto> update(Guid id, TDto tNew);

    Task<TDto> delete(TDto t);
}