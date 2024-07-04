using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MovieFinder.Data.Entities;

public class MovieEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null;
    [Required]
    public string Director { get; set; } = null;
    [Required]
    public string MpaRating { get; set; } = null;
    [Required]
    // [ForeignKey]
    public int Genre { get; set; }
}