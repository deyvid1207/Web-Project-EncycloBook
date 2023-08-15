using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.PostServices;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBookServices;
using EncycloBookServices.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class BaseController : Controller
    {
        public readonly IPostServices postServices;
        public readonly IFoodServices foodServices;
        public readonly IAllPostServices allPostServices;
        public readonly ISymptomServices symptomServices;
        public readonly IEditServices editServices;
        public readonly IUserServices userServices;

        public BaseController(IPostServices postServices, IFoodServices foodServices, ISymptomServices symptomServices, IEditServices editServices, IUserServices userServices)
        {
          this.postServices = postServices;
          this.foodServices = foodServices;
          this.symptomServices = symptomServices;
          this.editServices = editServices;
          this.editServices = editServices;
          this.userServices = userServices;
        }
    }
}
