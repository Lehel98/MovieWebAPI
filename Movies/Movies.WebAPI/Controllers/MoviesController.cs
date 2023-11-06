using Microsoft.AspNetCore.Mvc;
using Movies.WebAPI.Services;

namespace Movies.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMoviesService _service;

		public MoviesController(IMoviesService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Movie>> GetMovies()
		{
			return _service.GetMovies();
		}

		[HttpGet("{id}")]
		public ActionResult<Movie> GetMovie(Int32 id)
		{
			try
			{
				var movie = _service.GetMovieById(id);
				return movie != null ? movie : NotFound();
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public ActionResult<Movie> PostMovie(Movie movie)
		{
			if (movie is null)
			{
				return BadRequest("A hozzáadandó film értéke null!");
			}
			else if (_service.ContainsMovie(movie))
			{
				return Conflict($"Már létezik {movie.Title} című film! Nem lehet két azonos című film az adatbázisban!");
			}

			var newMovie = _service.AddMovie(movie);

			if (newMovie is null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			else
			{
				return CreatedAtAction(nameof(GetMovie), new { id = movie.Id });
			}
		}
	}
}
