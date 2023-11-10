using Microsoft.EntityFrameworkCore;

namespace Movies.WebAPI
{
	public static class DbInitializer
	{
		public static void Initialize(MovieDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			//if (context.Movies.Any())
			//	return;

			//context.Database.Migrate();		

			IList<Movie> movies = new List<Movie>()
			{
				new Movie
				{
					Title = "Spider-Man: Across the spiderverse",
					Genre = "Superheroes",
					Description = "Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.",
					ImdbRating = 9					
				}
			};

			context.AddRange(movies);
			context.SaveChanges();

			IList<Actor> actors = new List<Actor>()
			{
				new Actor
				{
					Name = "Shameik Moore",
					Age = 28,
					MovieId = 1
				},
				new Actor
				{
					Name = "Hailee Steinfeld",
					Age = 26,
					MovieId = 1
				},
				new Actor
				{
					Name = "Oscar Isaac",
					Age = 44,
					MovieId = 1
				}
			};

			IList<Review> reviews = new List<Review>()
			{
				new Review
				{
					Author = "Lehel",
					Text = "Ez egy nagyon jó film!",
					MovieId = 1
				}
			};

			context.AddRange(actors);
			context.AddRange(reviews);
			context.SaveChanges();
		}

		private static byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
				.Where(x => x % 2 == 0)
				.Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
				.ToArray();
		}
	}
}
