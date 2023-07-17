using EncycloData;
using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBookProject.Models;

namespace EncycloBookServices.Contacts
{
    public interface IEncycloServices
    {
        public ApplicationUser GetUser(string name);
        public Task PostAnimalAsync(Animal model);
        public AllViewModel ViewAll();
    }
}
