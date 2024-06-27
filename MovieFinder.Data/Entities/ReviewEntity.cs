using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Data.Entities;

public class ReviewEntity 
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int MovieId { get; set; }

  [Required]
  [ForeignKey(nameof(User))]
  public int UserId { get; set; }
  public UserEntity User { get; set; } = null!;

  [Required, Range(0.0, 10.0)]
  publi