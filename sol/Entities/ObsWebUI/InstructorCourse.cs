using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class InstructorCourse
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("InstructorId")]
		public int InstructorId { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("CourseId")]
		public int CourseId { get; set; }

	}
}
