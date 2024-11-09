using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movies_api.Data.Entities;

namespace movies_api.Controllers;

[ApiController]
[Route("api/[controller]/[Action]")]
public class MoviesController(DbContext _context) : ControllerBase
{
	[HttpPost]
	public ActionResult Add([FromBody] MovieEntity movieEntity)
	{
		_context.MovieEntity.Add(movieEntity);
		_context.SaveChanges();

		return Created();
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MovieEntity>))]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	public ActionResult Get([FromHeader] string apiKey)
	{
		var movies = _context.MovieEntity.ToList();

		if(apiKey.Length > 2)
		{
			return Forbid();
		}

		return StatusCode(200, movies);
	}

	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieEntity))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public ActionResult Get([FromRoute] int id)
	{
		var movie = _context.MovieEntity.FirstOrDefault(x => x.Id == id);

		if(movie == null)
		{
			return NotFound();
		}

        return Ok(movie);
	}
}
