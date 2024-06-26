using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Data.Entities;

public class ReviewEntity 
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int MovieId { get; set; }

  [Required]
  public int UserId { get; set; }

  [Required, Range(0.0, 10.0)]
  public double Rating { get; set; }

  [Required, MinLength(1), MaxLength(200)]
  public string Comment { get; set; } = string.Empty;
}