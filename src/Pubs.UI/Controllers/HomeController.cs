using Microsoft.AspNetCore.Mvc;
using Pubs.SharedKernel.Constants;
using Pubs.UI.Models;
using System.Diagnostics;

namespace Pubs.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
                
        }

        [Route("/", Name = RouteNames.Home)]
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
