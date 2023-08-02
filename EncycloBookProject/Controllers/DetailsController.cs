using EncycloBookServices.Contacts;
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

         
    }
}
