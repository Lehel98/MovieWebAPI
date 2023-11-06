namespace Movies.WebAPI.Services
{
	public interface IMoviesService
	{
		List<Movie> GetMovies();

		Movie? GetMovieById(int id);

		bool ContainsMovie(Movie movie);

		Movie? AddMovie(Movie movie);
	}
}
