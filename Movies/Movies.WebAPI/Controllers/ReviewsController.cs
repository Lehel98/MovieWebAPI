using Microsoft.AspNetCore.Mvc;
using Movies.WebAPI.Services;

namespace Movies.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMoviesService _service;

		public ReviewsController(IMoviesService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<string>> GetReviews()
		{
			return _service.GetReviews();
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<string>> GetReview(Int32 id)
		{
			return _service.GetReviews(id);
		}

		[HttpPost]
		public ActionResult<IEnumerable<string>> PostReview(int id, string review)
		{
			var result = _service.AddReview(id, review);

			if (result == null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			else
			{
				return result;
			}
		}
	}
}
