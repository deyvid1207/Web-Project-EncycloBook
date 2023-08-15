using EncycloBook.Data.Models.Posts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBookServices.Contacts;
using EncycloData.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IPostServices postServices, IFoodServices foodServices, ISymptomServices symptomServices, IEditServices editServices, IUserServices userServices) : base(postServices, foodServices, symptomServices, editServices, userServices)
        { 
        }
        [HttpGet]
        public IActionResult AccountPost(string username)
        {
            var user = userServices.GetUser(username);
            var model = postServices.ViewAll();
            List<Post> filtered = model.Posts.Where(x => x.PublisherId == user.Id).ToList();

            return View(filtered);
        }
        [HttpGet]
        public IActionResult SearchAcc(string username, string input)
        {
            var user = services.GetUser(username);
            var model = services.ViewAll();
            var selected = services.SearchAsync(input);
            List<Post> filtered = selected.Posts.Where(x => x.PublisherId == user.Id).ToList();
            return View("AccountPost", filtered);
 

 
        }
        [HttpGet]
        public IActionResult AccountDetails(string username)
        {
            var user = services.GetUser(username);

            return View(user);
        }
    }
}
 
