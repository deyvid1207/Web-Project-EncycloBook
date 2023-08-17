using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models.Properties;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Tests
{
    public class DataBaseSeeder
    {
        public static async void SeedDatabaseAsync(ApplicationDbContext dbContext)
        {
            var user = new ApplicationUser
            {
                Id = Guid.Parse("bf582c88-57e0-4c51-904c-c21bc9233f9f"),
                UserName = "exampleuser",
                Email = "example@example.com",
            };

            dbContext.Add(user);
            await dbContext.SaveChangesAsync();
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await dbContext.Symptoms.AddAsync(Symptom);
            await dbContext.SaveChangesAsync();
            var Food = new Food() { Id = 1, Name = "Test" };
            await dbContext.Food.AddAsync(Food);
            await dbContext.SaveChangesAsync();
            var Girrafe = new Animal()
            {

                Title = "Giraffe",
                AnimalClass = "Mammalia Giraffidae",
                AnimalSubClass = "Mammal",
                IsWild = true,
                Description = "The giraffe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaeus",
                YearDiscovered = 134,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = user.Id, // Set the foreign key value
            };
            await dbContext.Animals.AddAsync(Girrafe);
            await dbContext.SaveChangesAsync();
            var Edelweiss = new Plant()
            {

                Title = "Edelweiss",
                PlantClass = "Leontopodium nivale",
                Description = "Edelweiss (Leontopodium alpinum) is famous for its lance-shaped, wooly foliage and white, star-shaped flowers. These little flowers are naturally found growing in the high altitudes of the Alps and are accustomed to rocky soil, cold temperatures, and high winds. Edelweiss is a slow-growing plant and will begin flowering in its second year of growth.",
                DiscoveredBy = "Klaus Weiss",
                YearDiscovered = 1432,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Switzerland",
                StemType = "Aerogelius",
                RootType = "Taproot",
                Color = "White",
                LeaveType = "Simple",
                PublishedOn = DateTime.UtcNow,
                PublisherId = user.Id, // Set the foreign key value
            };
            await dbContext.Plants.AddAsync(Edelweiss);
            await dbContext.SaveChangesAsync();
            var Bac = new Bacteria()
            {
                Title = "Rhodococcus ruber",
                BacteriaFamily = "Nocardiaceae Rhodococcus",
                Description = "Rhodococcus ruber is a gram positive bacteria that is non-motile and non-spore forming.",
                DiscoveredBy = "William Zopf",
                PublishedOn = DateTime.UtcNow,
                IsDeadly = false,
                YearDiscovered = 1231,
                ImgURL = "https://microbewiki.kenyon.edu/images/6/64/Scanning-electron-microscope-SEM-photomicrograph-of-a-four-day-old-biofilm-of-R-ruber.png",
                Likes = new List<Like>(),
                PublisherId = user.Id,
            };
            await dbContext.Bacteria.AddAsync(Bac);
            await dbContext.SaveChangesAsync();
            var Parasitic = new ParasiticFungus()
            {
                Title = "Cordyceps",
                FungusClass = "Ophiocordyceps sinensis",
                Description = "Cordyceps is a fungus that has long been used in in traditional Chinese medicine (TCM). Some people use it to try to boost energy and strength, improve immunity, enhance kidney function, and improve sexual dysfunction. It has also been used to treat cough and fatigue. Cordyceps is known as an adaptogen, which means it may help your body adapt to stress.",
                Color = "Orange",
                IsParasitic = true,
                IsPoisonous = true,
                PublishedOn = DateTime.UtcNow,
                YearDiscovered = 1834,
                GillsType = "None",
                DiscoveredBy = "Wang Ang",
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/5/53/2010-08-06_Cordyceps_militaris_1.jpg",
                Host = "Ants",
                SymptomId = 7,
                Location = "Indonesia",

                PublisherId = user.Id,
                Likes = new List<Like>(),

            };
            await dbContext.Fungi.AddAsync(Parasitic);
            await dbContext.SaveChangesAsync();
            var fungus = new Fungus()
            {
                Title = "Mushroom",
                FungusClass = "Ophiocordyceps sinensis",
                Description = "Mushroom is a fungus that has long been used in in traditional Chinese medicine (TCM). Some people use it to try to boost energy and strength, improve immunity, enhance kidney function, and improve sexual dysfunction. It has also been used to treat cough and fatigue. Cordyceps is known as an adaptogen, which means it may help your body adapt to stress.",
                Color = "Orange",
                IsParasitic = false,
                IsPoisonous = false,
                PublishedOn = DateTime.UtcNow,
                YearDiscovered = 1834,
                GillsType = "None",
                DiscoveredBy = "Wang Ang",
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/5/53/2010-08-06_Cordyceps_militaris_1.jpg",
                Location = "Indonesia",

                PublisherId = user.Id,
                Likes = new List<Like>(),

            };
            await dbContext.Fungi.AddAsync(fungus);
            await dbContext.SaveChangesAsync();
            var virus = new Virus()
            {
                Id = 1,
                Title = "test",
                VirusFamily = "Virus",
                VirusHost = "Virus",

                Description = "Virus Virus, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = user.Id, // Set the foreign key value
            };
            await dbContext.Viruses.AddAsync(virus);
            await dbContext.SaveChangesAsync();
            var DeadlyBacteria = new DeadlyBacteria()
            {

                Id = 1,
                Title = "test",
                BacteriaFamily = "Mammaaalia Giraffidae",
                Host = "Black",
                IsDeadly = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = user.Id, // Set the foreign key value
            };
            await dbContext.Bacteria.AddAsync(DeadlyBacteria);
            await dbContext.SaveChangesAsync();
            var Comment = new Comment()
            {
                Id = 1,
                PublishedOn = DateTime.Now,
                PublisherId = user.Id,
                Content = "Test"
            };
            await dbContext.Bacteria.AddAsync(DeadlyBacteria);
            await dbContext.SaveChangesAsync();
        
        
        }
    }
}
