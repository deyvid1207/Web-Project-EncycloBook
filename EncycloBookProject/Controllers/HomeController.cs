    using EncycloBookProject.Models;
    using EncycloBookServices;
using EncycloBookServices.Contacts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

    namespace EncycloBookProject.Controllers
    {
        public class HomeController : BaseController
        {
            private readonly ILogger<HomeController> _logger;
 

            

        public HomeController(IEncycloServices services, ILogger<HomeController> logger) : base(services)
        {
            _logger = logger;
        }

        public IActionResult Index()
            {
                return View();
            }

            public IActionResult About()
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