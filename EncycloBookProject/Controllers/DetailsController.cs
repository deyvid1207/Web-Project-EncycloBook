﻿
using EncycloBook.Data.Models.Posts;
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.CommentServices.Contracts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.ViewModels.PostModels;

using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly IAllPostServices allPostServices;
        private readonly IFoodServices foodServices;
        private readonly ISymptomServices symptomServices;
        private readonly ICommentServices commentServices;
        private readonly IEditServices editServices;
        public DetailsController(IPostServices postServices, IFoodServices foodServices, ISymptomServices symptomServices, IEditServices editServices,ICommentServices commentServices, IUserServices userServices, IAllPostServices allPostServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
            this.allPostServices = allPostServices;
            this.foodServices = foodServices;
            this.symptomServices = symptomServices;
            this.commentServices = commentServices;
                

        }

        public async Task<IActionResult> ViewDetails(int postId, string postType)
        {
            try
            {
                var post = await postServices.FindPost(postId, postType);
                return View(post);
            }
    
             catch (Exception e)
            {

                return RedirectToAction("NotFound", "Error");
            }
           
        }
        public async Task  <IActionResult> AddComment(int postId, string postType, string username, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                // You may want to handle the case where the content is null or empty.
                // For example, you could return an error message or perform some action.
                return RedirectToAction("ViewDetails", new { postId = postId, postType = postType });
            }
            if (content != "COMMENT_VALUE_HERE")
            {

           
            var post =  await postServices.FindPost(postId, postType);
            var user = await userServices.GetUser(username);
            var comment = new Comment()
            {
                Content = content,
                PublishedOn = DateTime.Now,
                Publisher = user,
                PostId = postId,
                PublisherId = user.Id
            };
          await commentServices.CommentPost(post, user, comment);

            }
            return RedirectToAction("ViewDetails", new { postId = postId, postType = postType });
        }

        [HttpGet]
   
        public async  Task<IActionResult> EditAnimal(int id)
        {

            var AnimalVM = new AnimalWithFoodViewModel();
            AnimalVM.Foods = foodServices.GetFood();
    
            AnimalVM.Animal =   (Animal)await postServices.FindPost(id, "Animal");

            return View(AnimalVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnimal(AnimalWithFoodViewModel model)
        {

            model.Foods = foodServices.GetFood();
            var user = await userServices.GetUser(User.Identity.Name);
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
            if (IsWild == "True")
            {
                model.Animal.IsWild = true;

            }
            else
            {
                model.Animal.IsWild = false;
            }
            model.Animal.PublisherId = user.Id;
            model.Animal.Publisher = user;

            await editServices.EditAnimal(model.Animal);

            return RedirectToAction("ViewDetails", new { postId = model.Animal.Id, postType = "Animal" });
        }


        [HttpGet]
        public async Task<IActionResult> EditPlant(int id)
        {

          


           var  Plant = (Plant)await postServices.FindPost(id, "Plant");

            return View(Plant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlant(Plant model)
        {

      
         
            var user = await userServices.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await editServices.EditPlant(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Plant" });
        }
        [HttpGet]
        public async Task<IActionResult> EditFungus(int id)
        {


            var Fungus = (Fungus)await postServices.FindPost(id, "Fungus");

            return View(Fungus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFungus(Fungus model)
        {



            var user = await userServices.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await editServices.EditFungus(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Fungus" });
        }
        [HttpGet]

        public async Task<IActionResult> EditParasiticFungus(int id)
        {


            var FungusVM = new FungusWithSymptomsViewModel();
            FungusVM.ParasiticFungus = (ParasiticFungus)await postServices.FindPost(id, "ParasiticFungus");
            FungusVM.id = id;
            FungusVM.SymptomList = symptomServices.GetSymptoms();
            return View(FungusVM);

       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParasiticFungus(FungusWithSymptomsViewModel model)
        {

            model.ParasiticFungus.Id = model.id;
            string Host = Request.Form["Host"];
            switch (Host)
            {
                case null:
                    model.ParasiticFungus.Host = "Animals";
                    break;
                default:
                    model.ParasiticFungus.Host = Host;
                    break;

            }
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.ParasiticFungus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.ParasiticFungus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            var user = await userServices.GetUser(User.Identity.Name);
            model.ParasiticFungus.PublisherId = user.Id;
            model.ParasiticFungus.Publisher = user;
            await editServices.EditParasiticFungus(model.ParasiticFungus);

            return RedirectToAction("ViewDetails", new { postId = model.ParasiticFungus.Id, postType = "ParasiticFungus" });
        }


        [HttpGet]
        public async Task<IActionResult> EditBacteria(int id)
        {


            var Bacteria = new Bacteria();
            Bacteria = (Bacteria)await postServices.FindPost(id, "Bacteria");
            return View(Bacteria);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBacteria(Bacteria model)
        {

            var user = await userServices.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await editServices.EditBacteria(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Bacteria" });
        }
        [HttpGet]
        public async Task<IActionResult> EditDeadlyBacteria(int id)
        {


            var BacteriaVm = new BacteriaWithSymptomsViewModel();
            BacteriaVm.DeadlyBacteria = (DeadlyBacteria)await postServices.FindPost(id, "DeadlyBacteria");
            BacteriaVm.SymptomList = symptomServices.GetSymptoms();
            BacteriaVm.Id = id;
            return View(BacteriaVm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDeadlyBacteria(BacteriaWithSymptomsViewModel model)
        {

            var user = await userServices.GetUser(User.Identity.Name);
            model.DeadlyBacteria.PublisherId = user.Id;
            model.DeadlyBacteria.Id = model.Id;
            model.DeadlyBacteria.Publisher = user;
            string Host = Request.Form["Host"];
            switch (Host)
            {
                case null:
                    model.DeadlyBacteria.Host = "Animals";
                    break;
                default:
                    model.DeadlyBacteria.Host = Host;
                    break;

            }
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.DeadlyBacteria.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.DeadlyBacteria.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            await editServices.EditDeadlyBacteria(model.DeadlyBacteria);


            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "DeadlyBacteria" });

        }
        public async Task<IActionResult> EditVirus(int id)
        {


            var VirusVm = new VirusWithSymptomsViewModel();
            VirusVm.Virus = (Virus)await postServices.FindPost(id, "Virus");
            VirusVm.SymptomList = symptomServices.GetSymptoms();
            VirusVm.Id = id;
            return View(VirusVm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVirus(VirusWithSymptomsViewModel model)
        {

            var user = await userServices.GetUser(User.Identity.Name);
            model.Virus.PublisherId = user.Id;
            model.Virus.Id = model.Id;
            model.Virus.Publisher = user;
            string Host = Request.Form["Host"];
            switch (Host)
            {
                case null:
                    model.Virus.VirusHost = "Animals";
                    break;
                default:
                    model.Virus.VirusHost = Host;
                    break;

            }
            string Symptom = Request.Form["symptoms"];
            if (Symptom == null)
            {
                model.Virus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.Virus.Symptom = symptomServices.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            try
            {
                 await editServices.EditVirus(model.Virus);
            }
            catch (Exception)
            {

                return RedirectToAction("InternalServerError", "Error");
            }
            


            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Virus" });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int postId, string postType)
        {

            await postServices.DeletePost(postId, postType);


            return RedirectToAction("ViewAll", "Post");
        }
     
        public async Task<IActionResult> RemoveComment (int commentid, int postId, string postType, string username)
        {
            var user = await userServices.GetUser(username);
            var post = await postServices.FindPost(postId, postType);
            await commentServices.RemoveComment(post, user, commentid);
            return RedirectToAction("ViewDetails", new { postId = postId, postType = postType });
        }
    }

}
 