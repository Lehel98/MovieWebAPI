using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Movies.WebAPI.Services
{
	public class MoviesService : IMoviesService
	{
		private readonly MovieDbContext _context;

		public MoviesService(MovieDbContext context)
		{
			_context = context;
		}

		public List<Movie> GetMovies()
		{
			return _context.Movies.ToList();
		}

		public Movie? GetMovieById(int id)
		{
			return _context.Movies.FirstOrDefault(x => x.Id == id);
		}

		public bool ContainsMovie(Movie movie)
		{
			return _context.Movies.FirstOrDefault(x => x.Title == movie.Title) != null;
		}

		public Movie? AddMovie(Movie movie)
		{
			try
			{
				_context.Add(movie);
				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				return null;
			}

			return movie;
		}

		public List<string> GetReviews()
		{
			var reviews = new List<string>();
			foreach (var movie in _context.Movies)
			{
				foreach (var review in movie.Reviews)
				{
					reviews.Add(review);
				}
			}

			return reviews;
		}

		public List<string> GetReviews(int id)
		{
			var movie = _context.Movies.FirstOrDefault(x => id == x.Id);
			var reviews = new List<string>();
			if (movie != null)
			{
				foreach (var review in movie.Reviews)
				{
					reviews.Add(review);
				}
			}

			return reviews;
		}

		public List<string>? AddReview(int id, string review)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie != null)
			{
				movie.Reviews.Add(review);
				try
				{
					_context.Update(movie);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					return null;
				}
				catch (DbUpdateException)
				{
					return null;
				}
			}

			return GetReviews();
		}
	}
}
