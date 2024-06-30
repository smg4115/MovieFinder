using MovieFinder.Models.Movie;

namespace MovieFinder.Services.Movie;

public interface IMovieService
{
    Task<bool> AddMovieAsync (MovieAdd model);
}