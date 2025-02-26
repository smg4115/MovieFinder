using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Movie;

public class MovieAdd
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Director { get; set; } = string.Empty;
    [Required]
    public string MpaRating { get; set; } = string.Empty;
    [Required]
    public int Genre { get; set; }

}