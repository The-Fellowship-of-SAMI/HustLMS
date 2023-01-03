namespace LetterManagement.Server.Services;

public interface ICrud<TDto>
{
    Task<IEnumerable<TDto>> get();

    Task<TDto> create(TDto tDto);

    Task<TDto> update(TDto tOld, TDto tNew);

    Task<TDto> delete(TDto t);
}