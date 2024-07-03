
using MovieFinder.Data.Entities;

namespace MovieFinder.Services.Genre;

public interface IGenreService
{
    Task<IEnumerable<GenreEntity>> GetGenreAsync();
    Task<GenreEntity> GetGenreByIdAsync(int id);
    Task AddGenreAsync(GenreEntity genre);
    Task UpdateGenreAsync(GenreEntity genre);
    Task DeleteGenreAsync(int id);
}