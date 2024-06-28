using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MovieFinder.Data.Entities;

public class MovieEntity
{
    [Key]
    public int MovieId { get; set; }
    [Required]
    public string MovieTitle { get; set; } = null;
    [Required]
    public string MovieDirector { get; set; } = null;
    [Required]
    public string MpaRating { get; set; } = null;
    [Required]
    public int MovieGenre { get; set; }
}