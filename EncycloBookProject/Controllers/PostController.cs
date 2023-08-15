using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
 
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class PostController : Controller
    {

        private readonly IAllPostServices allPostServices;
        private readonly IPostServices postServices;
        private readonly IFoodServices foodServices;
        private readonly ISymptomServices symptomServices;
        private readonly IEditServices editServices;
        public PostController(IAllPostServices allPostServices,IPostServices postServices, IFoodServices foodServices, ISymptomServices symptomServices, IEditServices editServices) 
        {
            this.symptomServices = symptomServices;
            this.postServices = postServices;
            this.allPostServices = allPostServices;
            this.foodServices = foodServices;
            this.editServices = editServices;

        }

        [HttpGet]
        public IActionResult ViewAll(string anchor)
        {
            var model = allPostServices.ViewAll();
            ViewBag.Anchor = anchor;
            return View(model);
        }
        [HttpGet]
        public IActionResult Search(string input) {
          
          var selected = allPostServices.SearchAsync(input);
            return View("ViewAll", selected);
        }
        public IActionResult Publish()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Like(int itemId, string type, string ViewD, string anchor)
        {
            var post = postServices.FindPost(itemId, type);
            await postServices.LikePost(post, User.Identity.Name);
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
