using MovieFinder.Models.Movie;

namespace MovieFinder.Services.Movie;

public interface IMovieService
{
    Task<MovieListItem?> AddMovieAsync (MovieAdd request);
    Task<IEnumerable<MovieListItem>> GetAllMoviesAsync();
    Task<MovieDetail?> GetMovieByIdAsync(int movieId);
    Task<bool> UpdateMovieAsync(MovieUpdate request);
    Task<bool> DeleteMovieAsync(int movieId);
}