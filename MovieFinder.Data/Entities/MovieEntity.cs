using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MovieFinder.Data.Entities;

public class MovieEntity
{
    public string MovieTitle { get; set; } = null;
    public string MovieDirector { get; set; } = null;
    public string MpaRating { get; set; } = null;
    public int MovieGenre { get; set; }
}