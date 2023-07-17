using EncycloBookServices;
using EncycloBookServices.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class PostController : BaseController
    {
        public PostController(IEncycloServices services) : base(services)
        {
        }

        [HttpGet]
        public IActionResult ViewAll()
        {
            var model = services.ViewAll();
            return View(model);
        }
        public IActionResult Publish()
        {
            return View();
        }
    }
}
