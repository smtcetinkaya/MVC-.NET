using Bogus;

namespace wo3.Models
{
	public class SchoolDb
	{
		public static List<Student> Students = new List<Student>();
		public static void InitializeDb(int number) 
		{
			if (Students.Count == 0) 
			{
				for (int i = 1; i <= number; i++)
				{
					var student = new Faker<Student>()
						.RuleFor(s => s.Id, f => i)
						.RuleFor(s => s.Name, f => f.Name.FullName())
						.RuleFor(s => s.Email, (f, s) => f.Internet.Email(s.Name))
						.RuleFor(s => s.Age, f => f.Random.Int(18, 30));
					Students.Add(student);

				}
			}
		}
	}
}
