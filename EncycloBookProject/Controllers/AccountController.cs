using EncycloBookServices.Contacts;
using EncycloData.Migrations;
using EncycloData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IEncycloServices services) : base(services)
        { 
        }
        [HttpGet]
        public IActionResult AccountPost(string username)
        {
            var user = services.GetUser(username);
            var model = services.ViewAll();
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
    }
}
 
