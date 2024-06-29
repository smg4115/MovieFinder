using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFinder.Models.Review;

public class ReviewDetail
{
  public int Id { get; set; }
  public int MovieId { get; set; }
  public int UserId { get; set; }
  public double Rating { get; set; }
  public string Comment { get; set; } = string.Empty;
}