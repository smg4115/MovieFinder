using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFinder.Models.Movie;

public class MovieDetail
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string MpaRating { get; set; } = string.Empty;
    public int Genre { get; set; }
}