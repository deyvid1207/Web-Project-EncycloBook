using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class PublishController : Controller
    {
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
            return View("Animal");
        }
    }
}
