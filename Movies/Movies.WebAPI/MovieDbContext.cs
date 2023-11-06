using Microsoft.EntityFrameworkCore;

namespace Movies.WebAPI
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

		public DbSet<Movie> Movies { get; set; } = null!;

		public DbSet<Actor> Actors { get; set; } = null!;
    }
}
