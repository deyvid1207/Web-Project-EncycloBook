using Microsoft.AspNetCore.Mvc;

namespace EncycloBook.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }
    }
}
