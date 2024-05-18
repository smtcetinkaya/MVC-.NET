using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class Course
	{
		[Key]
		public int ıd { get; set; }

		[ForeignKey("DepartmentId")]
		[Required(ErrorMessage = "This is required!")]		
		public int DepartmentId { get; set; }

		[Required(ErrorMessage = "This is Required!")]
		public string? Name { get; set; }

	}
}
