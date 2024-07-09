using MovieFinder.Data;
using MovieFinder.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MovieFinder.Models.Movie;

namespace MovieFinder.Services.Movie;

public class MovieService : IMovieService
{
    private readonly ApplicationDbContext _dbContext;

    public MovieService(UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager,
                        ApplicationDbContext dbContext)
    {
    _dbContext = dbContext;
    }

    public async Task<MovieListItem?> AddMovieAsync(MovieAdd request)
    {
        MovieEntity entity = new()
        {
            Title = request.Title,
            Director = request.Director,
            MpaRating = request.MpaRating,
            Genre = request.Genre
        };

        _dbContext.Movies.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges != 1)
        {
            return null;
        }

        MovieListItem response = new()
        {
            Title = entity.Title
        };
        return response;
    }

    public async Task<IEnumerable<MovieListItem>> GetAllMoviesAsync()
    {
        List<MovieListItem> movies = await _dbContext.Movies.Select(entity => new MovieListItem
        {
            Title = entity.Title
        }).ToListAsync();

        return movies;
    }

    public async Task<MovieDetail?> GetMovieByIdAsync(int movieId)
    {
        MovieEntity? entity = await _dbContext.Movies.FirstOrDefaultAsync(entity => entity.Id == movieId);

        return entity is null ? null : new MovieDetail
        {
            Id = entity.Id,
            Title = entity.Title,
            Director = entity.Director,
            MpaRating = entity.MpaRating,
            Genre = entity.Genre
        };
    }

    public async Task<bool> UpdateMovieAsync(MovieUpdate request)
    {
        MovieEntity? entity = await _dbContext.Movies.FindAsync(request.Id);

        // if (entity?.OwnerId != _userId)
        // return false;

        entity.Title = request.Title;
        entity.Director = request.Director;
        entity.MpaRating = request.MpaRating;
        entity.Genre = request.Genre;

        int numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteMovieAsync(int movieId)
    {
        var movieEntity = await _dbContext.Movies.FindAsync(movieId);

        // if (movieEntity?.OwnerId != _userId)
        // return false;

        _dbContext.Movies.Remove(movieEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }
}