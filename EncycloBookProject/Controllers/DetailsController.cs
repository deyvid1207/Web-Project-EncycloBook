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

            return RedirectToRoute("/Post/ViewAll");
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

            return RedirectToRoute("/Post/ViewAll");
        }
        [HttpGet]
        public IActionResult EditParasiticFungus(int id)
        {


            var FungusVM = new FungusWithSymptomsViewModel();
            FungusVM.ParasiticFungus = (ParasiticFungus)services.FindPost(id, "ParasiticFungus");
            FungusVM.SymptomList = services.GetSymptoms();
            return View(FungusVM);

       
        }
        [HttpPost]
        public async Task<IActionResult> EditParasiticFungus(ParasiticFungus model)
        {



            var user = services.GetUser(User.Identity.Name);
            model.PublisherId = user.Id;
            model.Publisher = user;
            await services.EditFungus(model);

            return RedirectToRoute("/Post/ViewAll");
        }
    }
}
