using System.ComponentModel.DataAnnotations;

namespace wo3.Models
{
	public class Student
	{

		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required!")]
		[MaxLength(30)]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Email is required!")]
		[EmailAddress(ErrorMessage = "Invalid email format!")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Age is required!")]
		[Range(18,30,ErrorMessage = "Age must be between 18 and 30.")]
		public int Age { get; set; }
	}
}
