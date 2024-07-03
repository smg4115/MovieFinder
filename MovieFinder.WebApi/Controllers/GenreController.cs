
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Data.Entities;
using MovieFinder.Services.Genre;
namespace MovieFinder.WebApi.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    } 

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenresController>>> GetGenres()
    {
        var genres = await _genreService.GetGenreAsync();
        return Ok(genres);
    }
    
     [HttpGet("{id}")]
    public async Task<ActionResult<GenreEntity>> GetGenre(int id)
    {
        var genre = await _genreService.GetGenreByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }
}