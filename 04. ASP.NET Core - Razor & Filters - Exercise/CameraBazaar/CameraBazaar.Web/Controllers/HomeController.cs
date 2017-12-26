namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        [MeasureTime]
        public IActionResult Index() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}