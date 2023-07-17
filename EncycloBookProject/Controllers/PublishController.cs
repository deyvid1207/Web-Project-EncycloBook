using EncycloBookServices;
using EncycloBookServices.Contacts;
using EncycloData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class PublishController : Controller
    {
        public readonly IEncycloServices services;
        public PublishController(IEncycloServices services)
        {
            this.services = services;
        }

        [HttpPost]
        public IActionResult RedirectAct()
        {
            string selectedValue = Request.Form["pref"];
            switch (selectedValue)
            {
                case "Animal":
                    return RedirectToAction("Animal");
                default:
                    return RedirectToPage("/");
     
            }
        }

        [HttpGet]
        public IActionResult Animal()
        {
            var Animal = new Animal();
            return View(Animal);
        }
        [HttpPost]
        public async Task<IActionResult> Animal(Animal model)
        {
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;

            await services.PostAnimalAsync(model);
            user.AnimalPosts.Add(model);
            return View("Animal");
        }
    }
}
