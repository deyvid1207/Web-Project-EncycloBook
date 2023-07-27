using EncycloBookServices.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBookProject.Controllers
{
    public class DetailsController : BaseController
    {
        public DetailsController(IEncycloServices services) : base(services)
        {
        }

        public IActionResult ViewDetails(int postId, string postType, string anchor)
        {

            var post = services.FindPost(postId, postType);

            ViewBag.Anchor = anchor;
            return View(post);
        }
    }
}
