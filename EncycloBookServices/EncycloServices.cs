using EncycloBookProject.Models;
using EncycloBookServices.Contacts;
using EncycloData;
using EncycloData.Models;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookServices
{
    public class EncycloServices : IEncycloServices
    {
        private readonly ApplicationDbContext dbContext;
        public EncycloServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ApplicationUser GetUser(string name)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Email == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task PostAnimalAsync(Animal model) {

            if (model == null)
            {
                throw new Exception("Animal is null, please enter it correct!");

            }
            else
            {
                var animal = new Animal()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    AnimalClass = model.AnimalClass,
                    Description = model.Description,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Likes = 0
                };
                
                await dbContext.Animals.AddAsync(animal);
            }
            await dbContext.SaveChangesAsync();

        }

        public AllViewModel ViewAll()
        {
            
            var all = new AllViewModel();

            all.Animals = dbContext.Animals;
            all.Plants = dbContext.Plants;
            all.Fungi = dbContext.Fungi;
            all.Bacterias = dbContext.Bacteria;
            all.Viruses = dbContext.Viruses;
            return all;
        }
    }
}
