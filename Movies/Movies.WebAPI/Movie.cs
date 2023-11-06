using System.ComponentModel.DataAnnotations;

namespace Movies.WebAPI
{
	public class Movie
	{
        public Movie()
        {
			Actors = new List<Actor>();
			Reviews = new List<string>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = null!;

		[Required]
		public string Genre { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		public int ActorId { get; set; }

		public ICollection<Actor> Actors { get; set; } = null!;

		public Byte[]? Poster { get; set; }

		[Required]
		public int ImdbRating { get; set; }

		public ICollection<string> Reviews { get; set; } = null!;
	}
}
