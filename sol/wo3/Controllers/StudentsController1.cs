using Microsoft.AspNetCore.Mvc;
using wo3.Models;

namespace wo3.Controllers
{
	public class StudentsController1 : Controller
	{
		public StudentsController1() 
		{
			SchoolDb.InitializeDb(50);
		}
		public IActionResult Index()
		{
			var students = SchoolDb.Students.OrderBy(p=> p.Id).ToList();
			return View(students);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			var maxId = SchoolDb.Students.Max(p => p.Id) + 1;
			student.Id = maxId;

			if (ModelState.IsValid)
			{
				SchoolDb.Students.Add((student));
				return RedirectToAction("Index");
			}
			return View(student);
		}

		[HttpGet]
		public IActionResult Edit(int studentId)
		{
			var student = SchoolDb.Students.FirstOrDefault(p => p.Id == studentId);
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{

			if (ModelState.IsValid)
			{
				var toBeRemoved = SchoolDb.Students.FirstOrDefault(s => s.Id == student.Id);
				SchoolDb.Students.Remove((toBeRemoved));
				SchoolDb.Students.Add((student));
				return RedirectToAction("Index");
			}
			return View(student);
		}

		[HttpGet]
		public IActionResult Delete(int studentId)
		{
			var student = SchoolDb.Students.FirstOrDefault(p => p.Id == studentId);

			SchoolDb.Students.Remove(student);
			return RedirectToAction("Index");
		}
	}
}
