using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class StudentCourse
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("StudentId")]
		public int StudentId { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("CourseId")]
		public int CourseId { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public string? semester { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[Range(1999,230)]
		public int year { get; set; }
	}
}
