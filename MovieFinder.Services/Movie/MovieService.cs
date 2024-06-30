using MovieFinder.Data;
using MovieFinder.Data.Entities;
using Microsoft.AspNetCore.Identity;

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
}