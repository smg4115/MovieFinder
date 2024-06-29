using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MovieFinder.Data;
using MovieFinder.Data.Entities;
using MovieFinder.Models.Review;

namespace MovieFinder.Services.Review;

public class ReviewService : IReviewService
{
  private readonly ApplicationDbContext _dbContext;
  private readonly int _userId;

  public ReviewService(UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager,
                        ApplicationDbContext dbContext)
    {
      var currentUser = signInManager.Context.User;
      var userIdClaim = userManager.GetUserId(currentUser);
      var hasValidId = int.TryParse(userIdClaim, out _userId);

      if (hasValidId == false)
      {
        throw new Exception("Attempted to build ReviewService without Id claim.");
      }

      _dbContext = dbContext;
    }

    public async Task<ReviewListItem?> CreateReviewAsync(ReviewCreate request)
    {
      ReviewEntity entity = new()
      {
        MovieId = request.MovieId,
        UserId = _userId,
        Rating = request.Rating,
        Comment = request.Comment
      };

      _dbContext.Reviews.Add(entity);
      var numberOfChanges = await _dbContext.SaveChangesAsync();

      if (numberOfChanges != 1)
      {
        return null;
      }

      ReviewListItem response = new()
      {
        Id = entity.Id,
        MovieId = entity.MovieId,
        UserId = entity.UserId
      };
      return response;
    }
    

    public async Task<IEnumerable<ReviewListItem>> GetAllReviewsAsync()
    {
      List<ReviewListItem> reviews = await _dbContext.Reviews
        .Select(entity => new ReviewListItem
        {
          Id = entity.Id,
          MovieId = entity.MovieId,
          UserId = entity.UserId,
        })
        .ToListAsync();

      return reviews;
    }

    public async Task<ReviewDetail?> GetReviewByIdAsync(int reviewId)
    {
      // Find the first review that has the given Id
      ReviewEntity? entity = await _dbContext.Reviews.FirstOrDefaultAsync(entity => entity.Id == reviewId);

      // If the not entity is null, return null
      return entity is null ? null : new ReviewDetail
      {
        Id = entity.Id,
        MovieId = entity.MovieId,
        UserId = entity.UserId,
        Rating = entity.Rating,
        Comment = entity.Comment
      };
    }
}