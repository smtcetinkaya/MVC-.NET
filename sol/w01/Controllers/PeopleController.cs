using Microsoft.AspNetCore.Mvc;
using w01.Models;

namespace w01.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutMe()
        {
            People people = new People
            {
                Age = 22,
                FullName = "Samet Çetinkaya",
                Id = 123
            };
            return View(people);
        }




    }


}
