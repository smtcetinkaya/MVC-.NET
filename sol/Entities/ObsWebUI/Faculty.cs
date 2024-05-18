using System.ComponentModel.DataAnnotations;

namespace Entities.ObsWebUI
{
	public class Faculty
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public string? DeanName { get; set; }

	}
}
