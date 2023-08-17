using EncycloBook.Data.Models;
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.CommentServices.Contracts;
using EncycloBook.Services.UserServices;
using EncycloBook.Services.UserServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EncycloBook.Web.Controllers
{
[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole<Guid>> roleManager;
            private UserManager<ApplicationUser> userManager;
            private readonly IUserServices userServices;
            private readonly ICommentServices commentServices;
            private readonly IAllPostServices allPostServices;

        public AdminController(RoleManager<IdentityRole<Guid>> _roleManager, UserManager<ApplicationUser> _userManager, IUserServices _userServices, ICommentServices commentServices, IAllPostServices allPostServices)
        {
            this.roleManager = _roleManager;
            this.userManager = _userManager;
            this.userServices = _userServices;
            this.commentServices = commentServices;
            this.allPostServices = allPostServices;
        }

        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                return BadRequest("This role is already created");
            }
            var role = new IdentityRole<Guid>(roleName);
            var result = await roleManager.CreateAsync(role);
            return Ok(result);
        }
        public async Task<IActionResult> SetAdmin(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.AddToRoleAsync(user, "Admin");

            return Ok(result);
        }
        public async Task<IActionResult> AdminPanel()
        {
            var allUsers = await userServices.GetAllUser();
            return View(allUsers);
        }
        public async Task<IActionResult> UserComments(Guid userId)
        {
            var user = await userServices.GetUser(userId);
            var allComments = await commentServices.GetAllUserComments(user);
            return View(allComments);
        }
        public async Task<IActionResult> UserPosts(Guid userId)
        {
            var user = await userServices.GetUser(userId);
             
            return View(user.Posts);
        }
    }
}
