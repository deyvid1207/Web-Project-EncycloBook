using EncycloBookServices.Contacts;
using EncycloBookServices.Models;
using EncycloData;
using EncycloData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class DetailsController : BaseController
    {
        public DetailsController(IEncycloServices services) : base(services)
        {
        }

        public IActionResult ViewDetails(int postId, string postType)
        {

            var post = services.FindPost(postId, postType);

            return View(post);
        }
        public IActionResult AddComment(int postId, string postType, string username, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                // You may want to handle the case where the content is null or empty.
                // For example, you could return an error message or perform some action.
                return BadRequest("Comment content cannot be null or empty.");
            }
            if (content != "COMMENT_VALUE_HERE")
            {

           
            var post = services.FindPost(postId, postType);
                var user = services.GetUser(username);
            var comment = new Comment()
            {
                Content = content,
                PublishedOn = DateTime.Now,
                Publisher = user,
                PublisherId = user.Id
            };
           services.CommentPost(post, user, comment);

            }
            return RedirectToAction("ViewDetails", new { postId = postId, postType = postType });
        }

        [HttpGet]
        public  IActionResult EditAnimal(int id)
        {

            var AnimalVM = new AnimalWithFoodViewModel();
            AnimalVM.Foods = services.GetFood();
    
            AnimalVM.Animal = (Animal)services.FindPost(id, "Animal");

            return View(AnimalVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditAnimal(AnimalWithFoodViewModel model)
        {

            model.Foods = services.GetFood();
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
                model.Animal.IsWild = false;
            }
            model.Animal.PublisherId = user.Id;
            model.Animal.Publisher = user;

            await services.EditAnimal(model.Animal);

            return RedirectToAction("ViewDetails", new { postId = model.Animal.Id, postType = "Animal" });
        }


        [HttpGet]
        public IActionResult EditPlant(int id)
        {

          


           var  Plant = (Plant)services.FindPost(id, "Plant");

            return View(Plant);
        }
        [HttpPost]
        public async Task<IActionResult> EditPlant(Plant model)
        {

      
         
            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.EditPlant(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Plant" });
        }
        [HttpGet]
        public IActionResult EditFungus(int id)
        {


            var Fungus = (Fungus)services.FindPost(id, "Fungus");

            return View(Fungus);
        }
        [HttpPost]
        public async Task<IActionResult> EditFungus(Fungus model)
        {



            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.EditFungus(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Fungus" });
        }
        [HttpGet]
        public IActionResult EditParasiticFungus(int id)
        {


            var FungusVM = new FungusWithSymptomsViewModel();
            FungusVM.ParasiticFungus = (ParasiticFungus)services.FindPost(id, "ParasiticFungus");
            FungusVM.id = id;
            FungusVM.SymptomList = services.GetSymptoms();
            return View(FungusVM);

       
        }
        [HttpPost]
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
                model.ParasiticFungus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.ParasiticFungus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            var user = services.GetUser(User.Identity.Name);
            model.ParasiticFungus.PublisherId = user.Id;
            model.ParasiticFungus.Publisher = user;
            await services.EditParasiticFungus(model.ParasiticFungus);

            return RedirectToAction("ViewDetails", new { postId = model.ParasiticFungus.Id, postType = "ParasiticFungus" });
        }


        [HttpGet]
        public IActionResult EditBacteria(int id)
        {


            var Bacteria = new Bacteria();
            Bacteria = (Bacteria)services.FindPost(id, "Bacteria");
            return View(Bacteria);


        }
        [HttpPost]
        public async Task<IActionResult> EditBacteria(Bacteria model)
        {

            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.EditBacteria(model);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Bacteria" });
        }
        [HttpGet]
        public IActionResult EditDeadlyBacteria(int id)
        {


            var BacteriaVm = new BacteriaWithSymptomsViewModel();
            BacteriaVm.DeadlyBacteria = (DeadlyBacteria)services.FindPost(id, "DeadlyBacteria");
            BacteriaVm.SymptomList = services.GetSymptoms();
            BacteriaVm.Id = id;
            return View(BacteriaVm);


        }
        [HttpPost]
        public async Task<IActionResult> EditDeadlyBacteria(BacteriaWithSymptomsViewModel model)
        {

            var user = services.GetUser(User.Identity.Name);
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
                model.DeadlyBacteria.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.DeadlyBacteria.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            await services.EditDeadlyBacteria(model.DeadlyBacteria);


            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "DeadlyBacteria" });

        }
        public IActionResult EditVirus(int id)
        {


            var VirusVm = new VirusWithSymptomsViewModel();
            VirusVm.Virus = (Virus)services.FindPost(id, "Virus");
            VirusVm.SymptomList = services.GetSymptoms();
            VirusVm.Id = id;
            return View(VirusVm);


        }
        [HttpPost]
        public async Task<IActionResult> EditVirus(VirusWithSymptomsViewModel model)
        {

            var user = services.GetUser(User.Identity.Name);
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
                model.Virus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Id == 1);
            }
            else
            {
                model.Virus.Symptom = services.GetSymptoms().FirstOrDefault(x => x.Name == Symptom);

            }
            await services.EditVirus(model.Virus);

            return RedirectToAction("ViewDetails", new { postId = model.Id, postType = "Virus" });

        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int postId, string postType)
        {

            await services.DeletePost(postId, postType);


            return RedirectToAction("ViewAll", "Post");
        }
    }

}
 