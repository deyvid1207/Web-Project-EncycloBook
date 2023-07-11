using Microsoft.AspNetCore.Mvc;

namespace EncycloBook.Controllers
{
    public class PostController : Controller
    {
        public IActionResult ViewAll()
        {
            return View();
        }
        public IActionResult Publish()
        {
            return View();
        }
    }
}
