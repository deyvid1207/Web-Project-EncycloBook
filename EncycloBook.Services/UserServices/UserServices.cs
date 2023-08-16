using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBook.Services.UserServices.Contracts;
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

        public ApplicationUser GetUser(string name)
        {
            var user = dbContext.Users.Include(x => x.Comments).Include(x => x.Posts).ThenInclude(x => x.Likes).Include(x => x.Posts)
        .ThenInclude(post => post.Comments).FirstOrDefault(x => x.Email == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
