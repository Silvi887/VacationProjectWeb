using System.Diagnostics;
using BookVacation.Models;
using Microsoft.AspNetCore.Mvc;
using VacationApp.Services.Core.Interface;
using VacationApp.ViewModels.Vacation;

namespace BookVacation.Controllers
{
    public class HomeController :BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly   IVacationService vacationService;

        public HomeController(ILogger<HomeController> logger, IVacationService vacService)
        {
            _logger = logger;
            this.vacationService = vacService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
