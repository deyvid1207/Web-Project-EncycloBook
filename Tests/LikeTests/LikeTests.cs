using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;

namespace EncycloBook.Tests.LikeTests
{
    public class LikeTests
    {
        private ApplicationDbContext dbContext;
        private IPostServices postServices;

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
        public async Task LikePostAddsLikeWhenNotAlreadyLiked()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "testUser",
                Email = "test@example.com"
            };
           await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            var post = new Animal
            {
                Id = 1,
                Title = "Test Animal",
                DiscoveredBy = "Discoverer Name", // Replace with actual discoverer name
                PublishedOn = DateTime.Now, // Set the publication date and time
                ImgURL = "https://example.com/image.jpg", // Replace with actual image URL
                Description = "This is a test animal description.", // Replace with the description
                PublisherId = user.Id, // Replace with actual publisher's GUID
                Location = "Test Location", // Set the animal's location
                AnimalClass = "Mammalia", // Set the animal's class
                AnimalSubClass = "Mammal", // Set the animal's subclass
                FoodId = 1, // Set the Food ID
                IsWild = true // Set whether the animal is wild or not
            };
           await dbContext.Animals.AddAsync(post);
            await dbContext.SaveChangesAsync();

            // Act
            await postServices.LikePost(post, user.UserName);
            var likedPost = await dbContext.Animals
                .Include(a => a.Likes)
                .FirstOrDefaultAsync(a => a.Id == post.Id);

            // Assert
            Assert.NotNull(likedPost);
            Assert.That(1, Is.EqualTo(likedPost.Likes.Count));
            Assert.That(user.Id, Is.EqualTo(likedPost.Likes.First().UserId));
        }

        [Test]
        public async Task LikePostRemovesLikeWhenAlreadyLiked()
        {
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
            // Test data setup
            var post = new Animal()
            {
                Id = 1,
                Title = "Test Animal",
                DiscoveredBy = "Discoverer Name", // Replace with actual discoverer name
                PublishedOn = DateTime.Now, // Set the publication date and time
                ImgURL = "https://example.com/image.jpg", // Replace with actual image URL
                Description = "This is a test animal description.", // Replace with the description
                PublisherId = user.Id, // Replace with actual publisher's GUID
                Location = "Test Location", // Set the animal's location
                AnimalClass = "Mammalia", // Set the animal's class
                AnimalSubClass = "Mammal", // Set the animal's subclass
                FoodId = 1, // Set the Food ID
                IsWild = true, // Set whether the animal is wild or not};
            };
            await dbContext.AddAsync(post);
            await dbContext.SaveChangesAsync();



       

            var like = new Like() { PostId = post.Id, UserId = user.Id };
            dbContext.Add(like);
            await dbContext.SaveChangesAsync();

            // Act
            await postServices.LikePost(post, user.UserName);

            // Assert
            Assert.That(0, Is.EqualTo(post.Likes.Count));
            // Additional assertions for likes can be added here
        }
        [Test]
        public async Task LikePostDoesntLikeWhenUserIsNull()
        {
            // Arrange
            var post = new Animal
            {
                Id = 1,
                Title = "Test Animal",
                DiscoveredBy = "Discoverer Name", // Replace with actual discoverer name
                PublishedOn = DateTime.Now, // Set the publication date and time
                ImgURL = "https://example.com/image.jpg", // Replace with actual image URL
                Description = "This is a test animal description.", // Replace with the description
                PublisherId = Guid.NewGuid(), // Replace with actual publisher's GUID
                Location = "Test Location", // Set the animal's location
                AnimalClass = "Mammalia", // Set the animal's class
                AnimalSubClass = "Mammal", // Set the animal's subclass
                FoodId = 1, // Set the Food ID
                IsWild = true // Set whether the animal is wild or not
            };
            await dbContext.Animals.AddAsync(post);
            await dbContext.SaveChangesAsync();

            // Act
            await postServices.LikePost(post, null);
            var likedPost = await dbContext.Animals
                .Include(a => a.Likes)
                .FirstOrDefaultAsync(a => a.Id == post.Id);

            // Assert
            Assert.That(0, Is.EqualTo(likedPost.Likes.Count));

        }
    }
}
