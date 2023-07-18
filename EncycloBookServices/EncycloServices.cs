using EncycloBookProject.Models;
using EncycloBookServices.Contacts;
using EncycloData;
using EncycloData.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                   
                    Title = model.Title,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    AnimalClass = model.AnimalClass,
                    Description = model.Description,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(animal);
                await dbContext.Animals.AddAsync(animal);
               


            }
            await dbContext.SaveChangesAsync();

        }
        public async Task PostPlantAsync(Plant model)
        {


            if (model == null)
            {
                throw new Exception("Plant is null, please enter it correct!");

            }
            else
            {
                var plant = new Plant()
                {

                    Title = model.Title,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    PlantClass = model.PlantClass,
                    Description = model.Description,
                    LeaveType = model.LeaveType,
                    Color = model.Color,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(plant);
                await dbContext.Plants.AddAsync(plant);



            }
            await dbContext.SaveChangesAsync();

        }
        public async Task PostFungusAsync(Fungus model)
        {


            if (model == null)
            {
                throw new Exception("Fungus is null, please enter it correct!");

            }
            else
            {
                var fungus = new Fungus()
                {

                    Title = model.Title,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    FungusClass = model.FungusClass,
                    Description = model.Description,
                    GillsType = model.GillsType,
                    IsPoisonous = model.IsPoisonous,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Color = model.Color,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(fungus);
                await dbContext.Fungi.AddAsync(fungus);



            }
            await dbContext.SaveChangesAsync();

     
        }
        public async Task PostBacteriaAsync(Bacteria model)
        {


            if (model == null)
            {
                throw new Exception("Bacteria is null, please enter it correct!");

            }
            else
            {
                var bacteria = new Bacteria()
                {

                    Title = model.Title,
                    ImgURL = model.ImgURL,
                    BacteriaFamily = model.BacteriaFamily,
                    Description = model.Description,
                    IsDeadly = model.IsDeadly, 
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(bacteria);
                await dbContext.Bacteria.AddAsync(bacteria);



            }
            await dbContext.SaveChangesAsync();

        }

        public AllViewModel ViewAll()
        {

            var all = new AllViewModel();
            all.Posts.AddRange(dbContext.Animals.Include(a => a.Publisher));
            all.Posts.AddRange(dbContext.Plants.Include(p => p.Publisher));
            all.Posts.AddRange(dbContext.Viruses.Include(v => v.Publisher));
            all.Posts.AddRange(dbContext.Bacteria.Include(b => b.Publisher));
            all.Posts.AddRange(dbContext.Fungi.Include(f => f.Publisher));

            return all;
        }

        public Animal FindAnimalById(int id)
        {
            var Animal = dbContext.Animals.Find(id);

            return Animal;
        }
    }
}
