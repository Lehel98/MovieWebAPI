namespace Movies.WebAPI.Services
{
	public interface IMoviesService
	{
		List<Movie> GetMovies();

		Movie? GetMovieById(int id);

		bool ContainsMovie(Movie movie);

		Movie? AddMovie(Movie movie);

		List<Review> GetReviews();

		List<Review> GetReviews(int id);

		List<Review>? AddReview(int id, string author, string text);
	}
}
