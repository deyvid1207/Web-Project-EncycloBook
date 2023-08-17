using EncycloBook.Data;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Properties;
using EncycloBook.Services.CommentServices.Contracts;
using EncycloBook.Services.CommentServices;

namespace EncycloBook.Tests.PostTests
{
    [TestFixture]
    public class DeleteTests
    {
        private ApplicationDbContext dbContext;
        private IPostServices postServices;
        private ICommentServices commentServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.postServices = new PostServices(this.dbContext);
            this.commentServices = new CommentServices(this.dbContext);

        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsAnimal()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Food = new Food()
            {
                Id = 1,
                Name = "Test",
            };
            await this.dbContext.AddAsync(Food);
            await this.dbContext.SaveChangesAsync();
            var Girrafe = new Animal()
            {
                Id = 1,
                Title = "Giraffaae",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                FoodId = 1,
                Comments = new List<Comment>() { 
                      
                },
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await postServices.PostAnimalAsync(Girrafe);
            await commentServices.CommentPost(Girrafe, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(Girrafe.Id, "Animal");
            var post = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id == Girrafe.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
           


        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsPlant()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var Plant = new Plant()
            {
                Id = 1,
                Title = "Test",
                PlantClass = "Test",
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                StemType = "Test",
                RootType = "Test",
                Color = "Test",
                LeaveType = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostPlantAsync(Plant);
            await commentServices.CommentPost(Plant, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(Plant.Id, "Plant");
            var post = await dbContext.Plants.FirstOrDefaultAsync(x => x.Id == Plant.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
       

        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsFungus()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var Fungus = new ParasiticFungus()
            {
                Id = 1,
                Title = "Mush",
                FungusClass = "Mammaaalia Giraffidae",
                Color = "Black",
                GillsType = "tEST",
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                IsParasitic = false,
                IsPoisonous = true,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await postServices.PostFungusAsync(Fungus);
            await commentServices.CommentPost(Fungus, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(Fungus.Id, "Fungus");
            var post = await dbContext.Fungi.FirstOrDefaultAsync(x => x.Id == Fungus.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
          

        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsParasiticFungus()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new ParasiticFungus()
            {

                Id = 1,
                Title = "Mush",
                FungusClass = "Mammaaalia Giraffidae",
                Color = "Black",
                GillsType = "tEST",
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                IsParasitic = true,
                IsPoisonous = true,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Host = "test",
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await postServices.PostFungusAsync(test);
            await commentServices.CommentPost(test, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(test.Id, "ParasiticFungus");
            var post = await dbContext.Fungi.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
 

        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsVirus()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new Virus()
            {
                Id = 1,
                Title = "Test",
                Comments = new List<Comment>(),
                VirusHost = "Test",
                SymptomId = 1,
                Symptom = Symptom,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                VirusFamily = "Test",

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostVirusAsync(test);
            await commentServices.CommentPost(test, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(test.Id, "Virus");
            var post = await dbContext.Viruses.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
            


        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsBacteria()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new DeadlyBacteria()
            {
                Id = 1,
                Title = "Test",
                BacteriaFamily = "Test",
                IsDeadly = false,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
             

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostBacteriaAsync(test);
            await commentServices.CommentPost(test, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(test.Id, "Bacteria");
            var post = await dbContext.Bacteria.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);

        }
        [Test]
        public async Task DeleteWorksCorrectlyWhenTypeIsDeadlyBacteria()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new DeadlyBacteria()
            {
                Id = 1,
                Title = "Test",
                BacteriaFamily = "Test",
                Host = "Test",
                IsDeadly = true,
                SymptomId = 1,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostBacteriaAsync(test);
            await commentServices.CommentPost(test, testUser, new Comment()
            {
                Content = "2",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid
            });
            await postServices.DeletePost(test.Id, "DeadlyBacteria");
            var post = await dbContext.Bacteria.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.That(0, Is.EqualTo(dbContext.Comments.Count()));
            Assert.IsNull(post);
          

        }
        [Test]
        public async Task DeleteDoesntWorkWhenTypeIsNull()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new DeadlyBacteria()
            {
                Id = 1,
                Title = "Test",
                BacteriaFamily = "Test",
                Host = "Test",
                IsDeadly = true,
                SymptomId = 1,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostBacteriaAsync(test);

         
            var post = await dbContext.Bacteria.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.ThrowsAsync<ArgumentException>(async () => await postServices.DeletePost(test.Id, null));


        }
        [Test]
        public async Task DeleteDoesntWorkWhenPostIsNull()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            var Symptom = new Symptom() { Name = "Test", Id = 1, IsLifeThreatening = false };
            await this.dbContext.AddAsync(Symptom);
            await this.dbContext.SaveChangesAsync();
            var test = new DeadlyBacteria()
            {
                Id = 1,
                Title = "Test",
                BacteriaFamily = "Test",
                Host = "Test",
                IsDeadly = true,
                SymptomId = 1,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostBacteriaAsync(test);


            var post = await dbContext.Bacteria.FirstOrDefaultAsync(x => x.Id == test.Id);
            Assert.ThrowsAsync<ArgumentException>(async () => await postServices.DeletePost(0, null));


        }
    }
    }
 