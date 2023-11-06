using Microsoft.EntityFrameworkCore;

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
	}
}
