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
using MovieFinder.Models.Movie;
using MovieFinder.Services.Movie;

namespace MovieFinder.WebApi.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    // HTTPPost
    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] MovieAdd request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _movieService.AddMovieAsync(request);
        if (response is not null)
        {
            return Ok(response);
        }

        return BadRequest(new TextResponse("Could not add movie."));
    }

    // HTTPGet
    [HttpGet("{movieId:int}")]
    public async Task<IActionResult> GetMovieById([FromRoute] int movieId)
    {
        MovieDetail? detail = await _movieService.GetMovieByIdAsync(movieId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

    // HTTPPut

    [HttpPut]
    public async Task<IActionResult> UpdateMovieById([FromBody] MovieUpdate request)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

        return await _movieService.UpdateMovieAsync(request)
            ? Ok("Movie updated successfully.")
            : BadRequest("Movie could not be updated.");
    }

    // HTTPDelete

    [HttpDelete("{movieId:int}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int movieId)
    {
        return await _movieService.DeleteMovieAsync(movieId)
            ? Ok($"Movie {movieId} was deleted succesfully.")
            : BadRequest($"Movie {movieId} could not be deleted.");
    }
}
