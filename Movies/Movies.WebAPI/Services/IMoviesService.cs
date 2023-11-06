namespace Movies.WebAPI.Services
{
	public interface IMoviesService
	{
		List<Movie> GetMovies();

		Movie? GetMovieById(int id);

		bool ContainsMovie(Movie movie);

		Movie? AddMovie(Movie movie);

		List<string> GetReviews();

		List<string> GetReviews(int id);

		List<string>? AddReview(int id, string review);
	}
}
