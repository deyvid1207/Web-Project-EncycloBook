using EncycloBook.Data.Models.Posts;
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.UserServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly IAllPostServices allPostServices;
        public AccountController(IPostServices postServices, IUserServices userServices,IAllPostServices allPostServices )
        { 
            this.postServices = postServices;
            this.userServices = userServices;
            this.allPostServices = allPostServices;
        }
        [HttpGet]
        public IActionResult AccountPost(string username)
        {
            var user = userServices.GetUser(username);
            var model = allPostServices.ViewAll();
            List<Post> filtered = model.Posts.Where(x => x.PublisherId == user.Id).ToList();

            return View(filtered);
        }
        [HttpGet]
        public IActionResult SearchAcc(string username, string input)
        {
            var user = userServices.GetUser(username);
            var model = allPostServices.ViewAll();
            var selected = allPostServices.SearchAsync(input);
            List<Post> filtered = selected.Posts.Where(x => x.PublisherId == user.Id).ToList();
            return View("AccountPost", filtered);
 

 
        }
        [HttpGet]
        public IActionResult AccountDetails(string username)
        {
            var user = userServices.GetUser(username);

            return View(user);
        }
    }
}
 
