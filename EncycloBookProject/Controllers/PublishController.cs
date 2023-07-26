﻿using EncycloBookServices;
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
            model.RootType = root;
            model.StemType = stem;
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
            var BacteriaVM = new BacteriaWithSymptomsViewModel();
            BacteriaVM.SymptomList = services.GetSymptoms();
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
                    model.DeadlyBacteria.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Id == 1);
                }
                else
                {
                    model.DeadlyBacteria.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

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
            var user = services.GetUser(User.Identity.Name);
            model.DeadlyBacteria.PublisherId = user.Id;
            model.DeadlyBacteria.Publisher = user;
            await services.PostBacteriaAsync(model.DeadlyBacteria);
            return RedirectToPage("/");
        }
        public IActionResult Virus()
        {
            var ViruswSymptoms = new VirusWithSymptomsViewModel();
            ViruswSymptoms.SymptomList = services.GetSymptoms();
            return View(ViruswSymptoms);
        }
        [HttpPost]
        public async Task<IActionResult> Virus(VirusWithSymptomsViewModel model)
        {
            string Host = Request.Form["Host"];
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.Virus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.Virus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

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
            var user = services.GetUser(User.Identity.Name);
            model.Virus.PublisherId = user.Id;
            model.Virus.Publisher = user;
            await services.PostVirusAsync(model.Virus);
            return RedirectToPage("/");
        }
    }
}
