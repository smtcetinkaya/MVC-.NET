using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsWebUI
{
	public class ExamResult
	{
		[Key]
		public int Id { get; set; }


		[Required(ErrorMessage = "This is Required!")]
		[ForeignKey("ExamId")]
		public int ExamID { get; set; }

		[ForeignKey("StudentId")]
		[Required(ErrorMessage = "This is Required!")]
		public int StudentId { get; set; }


		[Required(ErrorMessage = "This is Required!")]
		[Range(0,100,ErrorMessage = "The value should be between 0 t0 100!")]
		public Single Grade { get; set; }

	}
}
