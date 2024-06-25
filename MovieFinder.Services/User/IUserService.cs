using MovieFinder.Data.Entities;
using MovieFinder.Models.User;

namespace MovieFinder.Services.User;

public class IUserService
{
    public async Task<bool> RegisterUserAsync(UserRegister model);
    {
        UserEntity entity = new()
        {
        Email = model.Email,
        UserName = model.UserName,
        DateCreated = DateTime.Now
        }
    }
}