using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using EncycloBook.Data;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.EditServices;
using EncycloBook.Data.Models.Properties;
using NUnit.Framework;

namespace EncycloBook.Tests.PostTests
{
    [TestFixture]
    public class EditTests
    {
        private ApplicationDbContext dbContext;
        private IPostServices postServices;
        private IEditServices editServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.postServices = new PostServices(this.dbContext); 
            this.editServices = new EditServices(this.dbContext, this.postServices);  

        }

        [Test]
        public async Task AnimalGetsEditedCorrect()
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
            await this.dbContext.AddAsync(testUser);
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
                Food = Food,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await this.dbContext.AddAsync(Girrafe);
            await this.dbContext.SaveChangesAsync();
            var Edited = new Animal()
            {
                Id = 1,
                Title = "Test",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                FoodId = 1,
                Food = Food,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await editServices.EditAnimal(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(Girrafe.Title, Is.EqualTo(Edited.Title));

        }
        [Test]
        public async Task PlantGetsEditedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            await this.dbContext.AddAsync(testUser);
            await this.dbContext.SaveChangesAsync();

            var Rose = new Plant()
            {
                Id = 1,
                Title = "Rose",
                PlantClass = "Mammaaalia Giraffidae",
                Color = "Black",
                LeaveType = "tEST",
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                RootType = "test",
                StemType = "test",
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await this.dbContext.AddAsync(Rose);
            await this.dbContext.SaveChangesAsync();
            var Edited = new Plant()
            {
                Id = 1,
                Title = "Test",
                PlantClass = "Mammaaalia Giraffidae",
                Color = "Black",
                LeaveType = "tEST",
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                RootType = "test",
                StemType = "test",
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await editServices.EditPlant(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.AreEqual(Rose.Title, Edited.Title);

        }
        [Test]
        public async Task FungusGetsEditedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            await this.dbContext.AddAsync(testUser);
            await this.dbContext.SaveChangesAsync();

            var Fungus = new Fungus()
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
            await this.dbContext.AddAsync(Fungus);
            await this.dbContext.SaveChangesAsync();
            var Edited = new Fungus()
            {
                Id = 1,
                Title = "Test",
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
            await editServices.EditFungus(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(Fungus.Title, Is.EqualTo(Edited.Title));

        }
        [Test]
        public async Task ParFungusGetsEditedCorrect()
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
            await this.dbContext.AddAsync(testUser);
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
            await this.dbContext.AddAsync(test);
            await this.dbContext.SaveChangesAsync();
            var Edited = new ParasiticFungus()
            {
                Id = 1,
                Title = "Test",
                FungusClass = "Test",
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
            await editServices.EditParasiticFungus(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(Edited.Title));
            Assert.That(test.Description, Is.EqualTo(Edited.Description));

        }
        [Test]
        public async Task VirusGetsEditedCorrect()
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
            await this.dbContext.AddAsync(testUser);
            await this.dbContext.SaveChangesAsync();

            var test = new Virus()
            {
                Id = 1,
                Title = "test",
                VirusFamily = "Mammaaalia Giraffidae",
                VirusHost = "Black",
              
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await this.dbContext.AddAsync(test);
            await this.dbContext.SaveChangesAsync();
            var Edited = new Virus()
            {
                Id = 1,
                Title = "Edited",
                VirusFamily = "Mammaaalia Giraffidae",
                VirusHost = "Black",

                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
                await editServices.EditVirus(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(Edited.Title));

        }
        [Test]
        public async Task  DeadlyBacteriaGetsEditedCorrect()
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
            await this.dbContext.AddAsync(testUser);
            await this.dbContext.SaveChangesAsync();

            var test = new DeadlyBacteria()
            {
               
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
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await this.dbContext.AddAsync(test);
            await this.dbContext.SaveChangesAsync();
            var Edited = new DeadlyBacteria()
            {
                Id = test.Id,
                Title = "Edit",
                BacteriaFamily = "Edit",
                Host = "Edit",
                IsDeadly = true,
                Description = "Edit hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Edit",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Symptom = Symptom,
                SymptomId = 1,
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await editServices.EditDeadlyBacteria(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(Edited.Title));
            Assert.That(test.Description, Is.EqualTo(Edited.Description));
            Assert.That(test.BacteriaFamily, Is.EqualTo(Edited.BacteriaFamily));
            Assert.That(test.Host, Is.EqualTo(Edited.Host));
  

        }
        [Test]
        public async Task BacteriaGetsEditedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            await this.dbContext.AddAsync(testUser);
            await this.dbContext.SaveChangesAsync();

            var test = new Bacteria()
            {
       
                Title = "test",
                BacteriaFamily = "Mammaaalia Giraffidae",
            
                IsDeadly = false,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
            
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await this.dbContext.AddAsync(test);
            await this.dbContext.SaveChangesAsync();
            var Edited = new Bacteria()
            {
                Id = test.Id,
                Title = "test",
                BacteriaFamily = "Mammaaalia Giraffidae",
                IsDeadly = false,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await editServices.EditBacteria(Edited);

            // Retrieve the added animal from the context
            // Assert that the added animal is not null
            Assert.NotNull(Edited);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(Edited.Title));

        }
    }
}
