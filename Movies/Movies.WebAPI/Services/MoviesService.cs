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

		public List<Review> GetReviews()
		{
			return _context.Reviews.ToList();
		}

		public List<Review> GetReviews(int id)
		{
			return _context.Reviews.Where(x => x.MovieId == id).ToList();
		}

		public List<Review>? AddReview(int id, string author, string text)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie != null)
			{				
				try
				{
					_context.Reviews.Add(new Review { Author = author, Text = text, MovieId = id });
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
