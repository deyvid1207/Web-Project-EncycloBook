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
        [HttpGet]
        public IActionResult Search(string input) {
          
          var selected = services.SearchAsync(input);
            return View("ViewAll", selected);
        }
        public IActionResult Publish()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Like(int itemId, string type)
        {
            
            await services.LikePost(itemId, type, User.Identity.Name);
          
            return RedirectToAction("ViewAll");
        }
    }
}
