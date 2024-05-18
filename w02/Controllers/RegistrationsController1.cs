using Microsoft.AspNetCore.Mvc;
using w02.Models;

namespace w02.Controllers
{
	public class RegistrationsController1 : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(StudentsDBtable.OrderBy(p=>p.Id).ToList());
		}

		public static List<Student> StudentsDBtable = new List<Student>()
		{
			new Student
			{
				Id = 1,
				FirstName = "samet",
				LastName = "Cetinkaya",
				Department = "Math.Eng."
			},
			new Student
			{
				Id = 2,
				FirstName = "aaa",
				LastName = "bbb",
				Department = "Math.Eng."
			}
		};

		[HttpGet]
		public IActionResult About(int id)
		{
			Student student = StudentsDBtable.FirstOrDefault(p => p.Id == id);

				/*
				ViewBag.id = id;
				ViewBag.firstName = "samet";
				ViewBag.lastName = "Cetinkaya";
				ViewBag.department = "Math. Eng.";
				*/


				/*
				ViewBag.id = id;
				ViewBag.firstName = "aa";
				ViewBag.lastName = "bbb";
				ViewBag.department = "Math. Eng.";
				*/


				/*
				ViewBag.id = -1;
				ViewBag.firstName = "xxx";
				ViewBag.lastName = "xxx";
				ViewBag.department = "xxx";
				*/

			return View(student);
		}

		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			// save data to db
			StudentsDBtable.Add((student));
			//home page show
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			Student student = StudentsDBtable.FirstOrDefault(p => p.Id == id);
			StudentsDBtable.Remove(student);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Student student = StudentsDBtable.FirstOrDefault(p => p.Id == id);
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			Student studentOld = StudentsDBtable.FirstOrDefault(p => p.Id == student.Id);
			StudentsDBtable.Remove(studentOld);
			StudentsDBtable.Add(student);
			return RedirectToAction("Index");
		}
	}
}
