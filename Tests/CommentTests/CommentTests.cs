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
using EncycloBook.Services.CommentServices.Contracts;
using EncycloBook.Services.CommentServices;

namespace EncycloBook.Tests.CommentTests
{
    public class CommentTests
    {
        private ApplicationDbContext dbContext;
        private ICommentServices commentServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.commentServices = new CommentServices(this.dbContext);

        }
        [Test]
        public async Task CommentPostAddsCommentToPostAndUserWhenUserNotNull()
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "testUser",
                Email = "test@example.com"
            };
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
            dbContext.Add(post);
            await dbContext.SaveChangesAsync();


            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = 1,
                Content = "A",
                PublishedOn = DateTime.Now,
                PublisherId = user.Id
            };

            // Act
            await commentServices.CommentPost(post, user, comment);

            // Assert
            Assert.AreEqual(1, post.Comments.Count);
            Assert.AreEqual(1, user.Comments.Count);
            // Additional assertions for comments can be added here
        }

        [Test]
        public async Task CommentPostDoesNotAddCommentWhenUserIsNull()
        {

            ApplicationUser user = null;
            // Test data setup
            var post = new Animal()
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
                IsWild = true, // Set whether the animal is wild or not};

            };
            dbContext.Add(post);
            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = 1,
                Content = "A",
                PublishedOn = DateTime.Now,
                PublisherId = Guid.NewGuid(),
            };

            // Act
            await commentServices.CommentPost(post, user, comment);

            // Assert
            Assert.AreEqual(0, post.Comments.Count);

        }
    }
}
