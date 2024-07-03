using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MovieFinder.Models.Responses;
using MovieFinder.Models.Review;
using MovieFinder.Services.Review;

namespace MovieFinder.WebApi.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // Post api/Review
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] ReviewCreate request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _reviewService.CreateReviewAsync(request);
        if (response is not null)
        {
            return Ok(response);
        }

        return BadRequest(new TextResponse("Could not create review"));
    }

    // Get api/Review/#
    [HttpGet("{reviewId:int}")]
    public async Task<IActionResult> GetReviewByIdAsync([FromRoute] int reviewId)
    {
        ReviewDetail? detail = await _reviewService.GetReviewByIdAsync(reviewId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }

    // Put api/Review
    [HttpPut]
    public async Task<IActionResult> UpdateReviewById([FromBody] ReviewUpdate request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return await _reviewService.UpdateReviewAsync(request)
            ? Ok("Review updated successfully.")
            : BadRequest("Review could not be updated.");
    }

    // Delete api/Review/#
    [HttpDelete("{reviewId:int}")]
    public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
    {
   