using MovieFinder.Models.User;

namespace MovieFinder.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
}