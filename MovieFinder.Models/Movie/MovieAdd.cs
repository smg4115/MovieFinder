using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Movie;

public class MovieAdd
{
    [Required]
    public string MovieTitle { get; set; } = string.Empty;
    [Required]
    public string MovieDirector { get; set; } = string.Empty;
    [Required]
    public string MpaRating { get; set; } = string.Empty;
    [Required]
    public int MovieGenre { get; set; }

}