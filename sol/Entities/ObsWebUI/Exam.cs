using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class Exam
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("CourseId")]
		[Required(ErrorMessage = "This is Required!")]
		public int CourseID { get; set; }
		[Required(ErrorMessage = "This is Required!")]
		public DateTime ExamDate { get; set; }
	}
}
