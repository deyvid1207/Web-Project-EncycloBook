using EncycloBookServices;
using EncycloBookServices.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class BaseController : Controller
    {
        public readonly IEncycloServices services;
        public BaseController(IEncycloServices services)
        {
            this.services = services;
        }
    }
}
