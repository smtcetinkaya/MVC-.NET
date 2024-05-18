using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "This is required!")]
		public string name { get; set; }

		[ForeignKey("DepartmentId")]
		[Required(ErrorMessage = "This is required!")]
		public int DepartmentId { get; set; }

	}
}
