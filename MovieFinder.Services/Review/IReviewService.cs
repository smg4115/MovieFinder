using MovieFinder.Models.Review;

namespace MovieFinder.Services.Review;

public interface IReviewService
{
  Task<ReviewListItem?> CreateReviewAsync(ReviewCreate request);
  Task<IEnumerable<ReviewListItem>> GetAllReviewsAsync();
  Task<ReviewDetail?> GetReviewByIdAsync(int reviewId);
}