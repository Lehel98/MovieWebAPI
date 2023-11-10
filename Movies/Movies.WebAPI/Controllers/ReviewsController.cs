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
		public ActionResult<IEnumerable<Review>> GetReviews()
		{
			return _service.GetReviews();
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Review>> GetReview(Int32 id)
		{
			return _service.GetReviews(id);
		}

		[HttpPost]
		public ActionResult<IEnumerable<Review>> PostReview(int id, string author, string review)
		{
			var result = _service.AddReview(id, author, review);

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
