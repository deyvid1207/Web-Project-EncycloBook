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
                case "Plant":
                    return RedirectToAction("Plant");
                case "Fungus":
                    return RedirectToAction("Fungus");
                case "Bacteria":
                    return RedirectToAction("Bacteria");
                case "Virus":
                    return RedirectToAction("Virus");
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
          
            return RedirectToRoute("/Post/ViewAll");
        }

        [HttpGet]
        public IActionResult Plant()
        {
            var Plant = new Plant();
            return View(Plant);
        }
        [HttpPost]
        public async Task<IActionResult> Plant(Plant model)
        {
            string color = Request.Form["color"];
            if (color.Contains("Different"))
            {
                color = color.Remove(0, 10);
            }
            var leaveType = Request.Form["leavetype"];
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            model.Color = color;
            model.LeaveType = leaveType;
            await services.PostPlantAsync(model);

            return RedirectToRoute("/Post/ViewAll");
        }
        [HttpGet]
        public IActionResult Fungus()
        {
            var Fungus = new Fungus();
            return View(Fungus);
        }
        [HttpPost]
        public async Task<IActionResult> Fungus(Fungus model)
        {
            string color = Request.Form["color"];
            if (color.Contains("Different"))
            {
                color = color.Remove(0, 10);
            }
            var gillsType = Request.Form["gillsType"];
            var isSafe = Request.Form["Safety"];
            if (isSafe == "Eddible")
            {
                model.IsPoisonous = false;
            }
            else
            {
                model.IsPoisonous = true;
            }
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            model.Color = color;
            model.GillsType = gillsType;
            await services.PostFungusAsync(model);
            return RedirectToRoute("/Post/ViewAll");
        }
        [HttpGet]
        public IActionResult Bacteria()
        {
            var Bacteria = new Bacteria();
            return View(Bacteria);
        }
        [HttpPost]
        public async Task<IActionResult> Bacteria(Bacteria model)
        {
            var isSafe = Request.Form["Safety"];
            if (isSafe == "Deadly")
            {
                model.IsDeadly = true;
            }
            else
            {
                model.IsDeadly = true;
            }
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.PostBacteriaAsync(model);
            return RedirectToPage("/");
        }
        public IActionResult Virus()
        {
            var Virus = new Virus();
            return View(Virus);
        }
        [HttpPost]
        public async Task<IActionResult> Virus(Virus model)
        {
            string Host = Request.Form["Host"];
            switch (Host)
            {
                case "Animals":
                    model.VirusHost = "Animals";
                    break;
                case "Plants":
                    model.VirusHost = "Plant";
                    break;
                case "Fungus":
                    model.VirusHost = "Fungus";
                    break;
                case "Bacteria":
                    model.VirusHost = "Bacteria";
                    break;
                case "Virus":
                    model.VirusHost = "Virus";
                    break;
                default:
                    throw new Exception("Select a valid virus host!");

            }
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.PostVirusAsync(model);
            return RedirectToPage("/");
        }
    }
}
