using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomExceptionFilter]
        public IActionResult Index()
        {
            int x = 10;
            int y = 0;
            //int z = x / y;
            return View();
        }

        [CustomResultFilterAttribute]
        public IActionResult Privacy()
        {
            return View();
        }

        [CustomLoggingActionFilter]
        public IActionResult Hello()
        {
            return View();
        }

        
    }
}