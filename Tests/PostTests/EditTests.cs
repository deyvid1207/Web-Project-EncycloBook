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

namespace EncycloBook.Tests.PostTests
{
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
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.postServices = new PostServices(this.dbContext); 
            this.editServices = new EditServices(this.dbContext, this.postServices);  

        }
        [TearDown]
        public void TearDown()
        {
            // Dispose of the current DbContext to clear the in-memory database
            this.dbContext.Dispose();
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
            Assert.AreEqual(Girrafe.Title, Edited.Title);

        }
    }
}
