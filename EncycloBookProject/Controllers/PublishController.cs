
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.ViewModels.PostModels;
using EncycloBook.Data.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace EncycloBookProject.Controllers
{
    public class PublishController : Controller
    {

        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly IAllPostServices allPostServices;
        private readonly IFoodServices foodServices;
        private readonly ISymptomServices symptomServices;
        private readonly IEditServices editServices;
        public PublishController(IPostServices postServices, IFoodServices foodServices, ISymptomServices symptomServices, IEditServices editServices, IUserServices userServices, IAllPostServices allPostServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
            this.allPostServices = allPostServices;
            this.foodServices = foodServices;
            this.symptomServices = symptomServices;
            this.editServices = editServices;     
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
                    return RedirectToAction("ViewAll", "Post");

            }
        }

        [HttpGet]
        public IActionResult Animal()
        {
            var AnimalVM = new AnimalWithFoodViewModel();
            AnimalVM.Foods = foodServices.GetFood();
            return View(AnimalVM);
        }
        [HttpPost]
        public async Task<IActionResult> Animal(AnimalWithFoodViewModel model)
        {
            model.Foods = foodServices.GetFood();
            var user = userServices.GetUser(User.Identity.Name);
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

            await postServices.PostAnimalAsync(model.Animal);

            return RedirectToAction("ViewAll", "Post");
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
            string stem = Request.Form["stemType"];
            if (stem == "null")
            {
                stem = "Aerial";
            }
            string root = Request.Form["rootType"];
            if (root == "null")
            {
                root = "Taproot";
            }
            string color = Request.Form["color"];
            if (color == null)
            {
                color = "Blue";

            }
         
            string leaveType = Request.Form["leavetype"];
            if (leaveType == null)
            {
                leaveType = "Simple";

            }
            var user = userServices.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.RootType = root;
            model.StemType = stem;
            model.Publisher = user;
            model.Color = color;
            model.LeaveType = leaveType;
            await postServices.PostPlantAsync(model);

            return RedirectToAction("ViewAll", "Post");
        }
        [HttpGet]
        public IActionResult Fungus()
        {
            var FungusVM = new FungusWithSymptomsViewModel();
            FungusVM.SymptomList = symptomServices.GetSymptoms();
            return View(FungusVM);
        }
        [HttpPost]
        public async Task<IActionResult> Fungus(FungusWithSymptomsViewModel model)
        {
            string IsParasitic = Request.Form["Parasitic"];
            if (IsParasitic == "Parasitic")
            {
                model.ParasiticFungus.IsParasitic = true;
            }
            else
            {
                model.ParasiticFungus.IsParasitic = false;
            }
           
            if (model.ParasiticFungus.IsParasitic)
            {

          
            string Host = Request.Form["Host"];
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.ParasiticFungus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.ParasiticFungus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            switch (Host)
            {
                case null:
                    model.ParasiticFungus.Host = "Animals";
                    break;
                default:
                    model.ParasiticFungus.Host = Host;
                    break;

            }
            }
            string color = Request.Form["color"];
            if (color == null)
            {
                color = "Blue";

            }
        
            string gillsType = Request.Form["gillsType"];
            if (gillsType == null)
            {
                gillsType = "Adnate";

            }
            var isSafe = Request.Form["Safety"];
            if (isSafe == "Eddible")
            {
                model.ParasiticFungus.IsPoisonous = false;
            }
            else
            {
                model.ParasiticFungus.IsPoisonous = true;
            }
            var user = userServices.GetUser(User.Identity.Name);
            model.ParasiticFungus.PublisherId = user.Id;
            model.ParasiticFungus.Publisher = user;
            model.ParasiticFungus.Color = color;
            model.ParasiticFungus.GillsType = gillsType;
            await postServices.PostFungusAsync(model.ParasiticFungus);
            return RedirectToAction("ViewAll", "Post");
        }
        [HttpGet]
        public IActionResult Bacteria()
        {
            var BacteriaVM = new BacteriaWithSymptomsViewModel();
            BacteriaVM.SymptomList = symptomServices.GetSymptoms();
            return View(BacteriaVM);
        }
        [HttpPost]
        public async Task<IActionResult> Bacteria(BacteriaWithSymptomsViewModel model)
        {
            var isSafe = Request.Form["Safety"];
            if (isSafe == "Deadly")
            {
                model.DeadlyBacteria.IsDeadly = true;
                string Host = Request.Form["Host"];
                string Symptom = Request.Form["symptoms"];
                if (Symptom == null)
                {
                    model.DeadlyBacteria.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
                }
                else
                {
                    model.DeadlyBacteria.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

                }
                switch (Host)
                {
                    case null:
                        model.DeadlyBacteria.Host = "Animals";
                        break;
                    default:
                        model.DeadlyBacteria.Host = Host;
                        break;

                }
            }
            else
            {   
                model.DeadlyBacteria.IsDeadly = false;
            }
            var user = userServices.GetUser(User.Identity.Name);
            model.DeadlyBacteria.PublisherId = user.Id;
            model.DeadlyBacteria.Publisher = user;
            await postServices.PostBacteriaAsync(model.DeadlyBacteria);
            return RedirectToAction("ViewAll", "Post");
        }
        public IActionResult Virus()
        {
            var ViruswSymptoms = new VirusWithSymptomsViewModel();
            ViruswSymptoms.SymptomList = symptomServices.GetSymptoms();
            return View(ViruswSymptoms);
        }
        [HttpPost]
        public async Task<IActionResult> Virus(VirusWithSymptomsViewModel model)
        {
            string Host = Request.Form["Host"];
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.Virus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.Virus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            switch (Host)
            {
                case null:
                    model.Virus.VirusHost = "Animals";
                    break;
                 default:
                    model.Virus.VirusHost = Host;
                    break;

            }
            var user = userServices.GetUser(User.Identity.Name);
            model.Virus.PublisherId = user.Id;
            model.Virus.Publisher = user;
            await postServices.PostVirusAsync(model.Virus);
            return RedirectToAction("ViewAll", "Post");
        }
    }
}
