using System.ComponentModel.DataAnnotations;

namespace Movies.WebAPI
{
	public class Review
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Author { get; set; } = null!;

		[Required]
		public string Text { get; set; } = null!;

		public int MovieId { get; set; }

		public virtual Movie Movie { get; set; } = null!;
	}
}
