using EncycloBookServices;
using EncycloBookServices.Contacts;
using EncycloBookServices.Models;
using EncycloData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class PublishController : BaseController
    {
    

        public PublishController(IEncycloServices services) : base(services)
        {
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
            var AnimalVM = new AnimalWithFoodViewModel();
            AnimalVM.Foods = services.GetFood();
            return View(AnimalVM);
        }
        [HttpPost]
        public async Task<IActionResult> Animal(AnimalWithFoodViewModel model)
        {
            var user = services.GetUser(User.Identity.Name);
            string Aclass = Request.Form["class"];
            string food = Request.Form["food"];
            string IsWild = Request.Form["wild"];
            model.Animal.AnimalSubClass = Aclass;
            if (food == null)
            {
                model.Animal.Food = model.Foods.FirstOrDefault(x => x.Id == 1);

            }
            else
            {
                model.Animal.Food = model.Foods.FirstOrDefault(x => x.Name == food);
            }
            if (IsWild == "true")
            {
                model.Animal.IsWild = false;

            }
            else
            {
                model.Animal.IsWild = true;
            } 
            model.Animal.PublisherId = user.Id;
            model.Animal.Publisher = user;

            await services.PostAnimalAsync(model.Animal);
          
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
            if (color == null)
            {
                color = "Blue";

            }
            if (color.Contains("Different"))
            {
                color = color.Remove(0, 10);
            }
            string leaveType = Request.Form["leavetype"];
            if (leaveType == null)
            {
                leaveType = "Simple";

            }
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
            if (color == null)
            {
                color = "Blue";

            }
            if (color.Contains("Different"))
            {
                color = color.Remove(0, 10);
            }
            string gillsType = Request.Form["gillsType"];
            if (gillsType == null)
            {
                gillsType = "Adnate";

            }
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
        public async Task<IActionResult> Bacteria(DeadlyBacteria model)
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
                    model.VirusHost = "Animals";
                    break;

            }
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.PostVirusAsync(model);
            return RedirectToPage("/");
        }
    }
}
