using EncycloBook.Data;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.AllPostsServices;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;

namespace EncycloBook.Tests.PostTests
{
    [TestFixture]
    public class MainPageTests
    {
        private ApplicationDbContext dbContext;
        private IPostServices postServices;
        private IAllPostServices allpostServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.postServices = new PostServices(this.dbContext);
            this.allpostServices = new AllPostServices(this.dbContext);

        }
        [Test]
        public async Task ViewAllReturnsAllPosts()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            // Test data setup
            var animal = new Animal()
            {
                Title = "Giraffaae",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 123,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser
            };
            var plant = new Plant()
            {
                Title = "Test",
                PlantClass = "Test",
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 123,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                StemType = "Test",
                RootType = "Test",
                Color = "Test",
                LeaveType = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value};
            };

          await  dbContext.AddRangeAsync(animal, plant);

           await dbContext.SaveChangesAsync();

            var result = allpostServices.ViewAll();

            Assert.That(2, Is.EqualTo(result.Posts.Count));

        }
        [Test]
        public void SearchReturnsMatchingPostsWhenSearchTextExists()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            // Test data setup
            var animal = new Animal()
            {
                Title = "Lion",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 231,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser
            };
            var plant = new Plant()
            {
                Title = "Rose",
                PlantClass = "Test",
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 321,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                StemType = "Test",
                RootType = "Test",
                Color = "Test",
                LeaveType = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value};
            };   // Create and add more test data for other entities

            dbContext.AddRange(animal, plant); // Add more entities

            dbContext.SaveChanges();

            // Act
            var result = allpostServices.SearchAsync("lion");

            // Assert
            Assert.That(1, Is.EqualTo(result.Posts.Count));
            Assert.That("Lion", Is.EqualTo(result.Posts[0].Title));
            // Additional assertions for specific properties can be added here
        }
        [Test]
        public void SearchAsyncReturnsAllPostsWhenSearchTextIsNull()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            // Test data setup
            var animal = new Animal()
            {
                Title = "Lion",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = 34,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser
            };
            var plant = new Plant()
            {
                Title = "Rose",
                PlantClass = "Test",
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = 34,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Test",
                StemType = "Test",
                RootType = "Test",
                Color = "Test",
                LeaveType = "Test",
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value};
            };
            // Create and add more test data for other entities

            dbContext.AddRange(animal, plant); // Add more entities

            dbContext.SaveChanges();

            // Act
            var result = allpostServices.SearchAsync(null);

            // Assert
            Assert.That(2, Is.EqualTo(result.Posts.Count)); // Adjust count based on your test data
            // Additional assertions for specific properties can be added here
        }
        
    }
}
