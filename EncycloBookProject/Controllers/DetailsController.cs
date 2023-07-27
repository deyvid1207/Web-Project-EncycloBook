using EncycloBookServices.Contacts;
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
    }
}
