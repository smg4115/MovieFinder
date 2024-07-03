using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Data.Entities;

namespace MovieFinder.Services.Genre;

public class GenreService : IGenreService
{
    private readonly ApplicationDbContext _context;

    public GenreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GenreEntity>> GetGenreAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<GenreEntity> GetGenreByIdAsync(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task AddGenreAsync(GenreEntity genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGenreAsync(GenreEntity genre)
    {
        _context.Entry(genre).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGenreAsync(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre != null)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }

}