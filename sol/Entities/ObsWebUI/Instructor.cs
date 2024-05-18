using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class Instructor
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("DepartmentId")]
		public int DepartmentId { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public string? Name { get; set; }

	}
}
