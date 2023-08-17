using EncycloBook.Data;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;


namespace EncycloBook.Tests.PostTests
{

    [TestFixture]
    public class AddTests
    {
        private ApplicationDbContext dbContext;
        private IPostServices  postServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.postServices = new PostServices(this.dbContext);

        }
    
    
        [Test]
        public async Task AnimalGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var Girrafe = new Animal()
            {

                Title = "Giraffaae",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 143,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await postServices.PostAnimalAsync(Girrafe);

            // Retrieve the added animal from the context
            var addedAnimal = await dbContext.Animals.FirstOrDefaultAsync(a => a.Title == "Giraffaae");

            // Assert that the added animal is not null
            Assert.NotNull(addedAnimal);

            // Assert the properties of the added animal
            Assert.That(Girrafe.Title, Is.EqualTo(addedAnimal.Title));
            Assert.That(Girrafe.AnimalClass, Is.EqualTo(addedAnimal.AnimalClass));
            Assert.That(Girrafe.AnimalSubClass, Is.EqualTo(addedAnimal.AnimalSubClass));
            Assert.That(Girrafe.Description, Is.EqualTo(addedAnimal.Description));

        }
        [Test]
        public async Task PostAnimalThrowsWhenNull()
        {
            Assert.ThrowsAsync<Exception>(async() => await postServices.PostAnimalAsync(null));

        }
        [Test]
        public async Task PlantGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
               var Plant = new Plant() { 
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

            // Retrieve the added animal from the context
            var addedPlant = await dbContext.Plants.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedPlant);

            // Assert the properties of the added animal
            Assert.That(Plant.Title, Is.EqualTo(addedPlant.Title));
            // ... (other property assertions)
        }
        [Test]
        public async Task PostPlantThrowsWhenNull()
        {
            Assert.ThrowsAsync<Exception>(async () => await postServices.PostPlantAsync(null));
        }
        [Test]
        public async Task FungusGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var test = new ParasiticFungus()
            {

                Title = "Test",
                IsPoisonous = false,
                IsParasitic = false,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                GillsType = "Test",
                FungusClass = "Test",
                Color = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostFungusAsync(test);

            // Retrieve the added animal from the context
            var addedFungus = await dbContext.Fungi.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedFungus);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(addedFungus.Title));
            // ... (other property assertions)
        }
        [Test]
        public async Task PostFungusThrowsWhenNull()
        {
            Assert.ThrowsAsync<Exception>(async () => await postServices.PostFungusAsync(null));
        }
        [Test]
        public async Task ParasiticFungusGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var test = new ParasiticFungus()
            {

                Title = "Test",
                IsPoisonous = false,
                IsParasitic = true,
                Host = "Test",
                SymptomId = 7,
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 234,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                GillsType = "Test",
                FungusClass = "Test",
                Color = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await postServices.PostFungusAsync(test);

            // Retrieve the added animal from the context
            var addedFungus = await dbContext.Fungi.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedFungus);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(addedFungus.Title));
            // ... (other property assertions)
        }
        [Test]
        public async Task VirusGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var test = new Virus()
            {

                Title = "Test",

                VirusHost = "Test",
                SymptomId = 7,
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
                
            // Retrieve the added animal from the context
            var addedVirus = await dbContext.Viruses.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedVirus);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo(addedVirus.Title));
            // ... (other property assertions)
        }
        [Test]
        public async Task PostVirusThrowsWhenNull()
        {
            Assert.ThrowsAsync<Exception>(async () => await postServices.PostVirusAsync(null));
        }
        [Test]
        public async Task BacteraGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var test = new DeadlyBacteria()
            {

                Title = "Test",
                BacteriaFamily = "Test",
                Host = "Test",
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

            // Retrieve the added animal from the context
            var addedBac = await dbContext.Bacteria.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedBac);

            // Assert the properties of the added animal
            Assert.That(test.Title, Is.EqualTo( addedBac.Title));
            // ... (other property assertions)
        }
        [Test]
        public async Task PostBacteriaThrowsWhenNull()
        {
            Assert.ThrowsAsync<Exception>(async () => await postServices.PostBacteriaAsync(null));
        }
        [Test]
        public async Task DeadlyBacteraGetsAddedCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };

            var test = new DeadlyBacteria()
            {

                Title = "Test",
                BacteriaFamily = "Test",
                Host = "Test",
                IsDeadly = true,
                SymptomId = 7,
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

            // Retrieve the added animal from the context
            var addedBac = await dbContext.Bacteria.FirstOrDefaultAsync(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedBac);

            // Assert the properties of the added animal
            Assert.That(test.Title,Is.EqualTo( addedBac.Title));
            // ... (other property assertions)
        }
    }
}
