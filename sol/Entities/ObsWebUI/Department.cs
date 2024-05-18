using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class Department
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("FacultyId")]
		[Required(ErrorMessage = "This is Required!")]
		public int FacultyId { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public string? Name { get; set; }

	}
}
