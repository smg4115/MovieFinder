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

    [Require