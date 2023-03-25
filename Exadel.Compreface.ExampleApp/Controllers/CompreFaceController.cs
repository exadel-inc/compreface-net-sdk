using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.ExampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exadel.Compreface.ExampleApp.Controllers
{
    public class CompreFaceController : Controller
    {
        private readonly ICompreFaceClient _compreFaceClient;

        public CompreFaceController(ICompreFaceClient compreFaceClient)
        {
            _compreFaceClient = compreFaceClient;
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