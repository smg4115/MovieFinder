using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Movie;

public class MovieUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(30, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(20, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Director { get; set; } = string.Empty;
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(5, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string MpaRating { get; set; } = string.Empty;
    [Required]
    public int Genre { get; set; }
}