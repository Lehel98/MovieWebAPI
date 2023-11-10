using System.ComponentModel.DataAnnotations;

namespace Movies.WebAPI
{
	public class Movie
	{
        public Movie()
        {
			Actors = new List<Actor>();
			Reviews = new List<Review>();
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

		public virtual ICollection<Actor> Actors { get; set; }

		public Byte[]? Poster { get; set; }

		[Required]
		public int ImdbRating { get; set; }

		public int ReviewId { get; set; }

		public virtual ICollection<Review> Reviews { get; set; }
	}
}
