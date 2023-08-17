using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.ViewModels.UserViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext dbContext;


        public UserServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUser(string name)
        {
            var user = await dbContext.Users
                .Include(x => x.Comments)
                .Include(x => x.Posts).ThenInclude(x => x.Likes)
                .Include(x => x.Posts).ThenInclude(post => post.Comments)
                .FirstOrDefaultAsync(x => x.Email == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<ApplicationUser> GetUser(Guid id)
        {
            var user = await dbContext.Users
                .Include(x => x.Comments)
                .Include(x => x.Posts).ThenInclude(x => x.Likes)
                .Include(x => x.Posts).ThenInclude(post => post.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<AllUsersViewModel> GetAllUser()
        {
            AllUsersViewModel allUsers = new AllUsersViewModel();
            allUsers.Users = await dbContext.Users
                .Where(x => x.Id != Guid.Parse("224a25dd-ceb2-4d1c-bb49-fb99d66972b6"))
                .Include(x => x.Posts).ThenInclude(x => x.Comments)
                .Include(x => x.Posts).ThenInclude(x => x.Likes)
                .Include(x => x.Comments).ToListAsync();
            if (allUsers.Users == null)
            {
                return null;
            }
            return allUsers;
        }
    }
}
