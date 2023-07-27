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
        public IActionResult ViewAll(string anchor)
        {
            var model = services.ViewAll();
            ViewBag.Anchor = anchor;
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
        public async Task<IActionResult> Like(int itemId, string type, string ViewD, string anchor)
        {
            var post = services.FindPost(itemId, type);
            await services.LikePost(post, User.Identity.Name);
            switch (ViewD)
            {
                case "ViewAll":
                    return RedirectToAction("ViewAll", new { anchor = anchor });
                   
                case "ViewDetails":
                    return RedirectToAction("ViewDetails", "Details", new { postId = itemId, postType = type, anchor = anchor });
                default:
                    throw new ArgumentException("Enter valid parameters!");
                    
            }
         
        }
    }
}
