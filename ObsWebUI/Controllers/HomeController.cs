using Microsoft.AspNetCore.Mvc;
using Entities.ObsWebUI;
using System.Diagnostics;
using DataAccess.EfDbContext;
using Business.CommonServices.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace ObsWebUI.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}

		public IActionResult Index()
		{
			return View();
		}
	}
}
