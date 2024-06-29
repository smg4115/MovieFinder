using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFinder.Models.Review;

public class ReviewCreate
{
    [Required]
    public int MovieId { get; set; }

    [Required]
    public double Rating { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} character long")]
    [MaxLength(200, ErrorMessage = "{0} must be no more than {1} characters long")]
    public string Comment { get; set; } = string.Empty;
}