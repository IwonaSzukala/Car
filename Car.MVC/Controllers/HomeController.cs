using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Car.MVC.Models;
using MediatR;

namespace Car.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new About
            {
                title = "Car",
                description = "Opis",
                tags = new List<string> { "car", "app", "free" }
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new List<Person>
            {
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Person
                {
                    FirstName = "Adam",
                    LastName = "Małysz"
                }
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
