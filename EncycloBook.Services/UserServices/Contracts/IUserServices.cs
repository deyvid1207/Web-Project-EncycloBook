using EncycloBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.UserServices.Contracts
{
    public interface IUserServices
    {
        public Task<ApplicationUser> GetUser(string name);
 
    }
}
