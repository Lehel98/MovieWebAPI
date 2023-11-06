using System.ComponentModel.DataAnnotations;

namespace Movies.WebAPI
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public int Age { get; set; }

		public int MovieId { get; set; }

		public virtual Movie Movie { get; set; } = null!;
	}
}
