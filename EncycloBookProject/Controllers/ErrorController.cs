using EncycloBook.ViewModels.ControllerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBook.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        public IActionResult InternalServerError(string controllerName, string actionName)
        {
            var ControllerVM = new ControllerWithActionViewModel()
            {
                ActionName = actionName,
                ControllerName = controllerName,
            };
            Response.StatusCode = 500;
            return View(ControllerVM);
        }
    }
}
