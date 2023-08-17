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
using System.Composition.Convention;
using Microsoft.Extensions.Hosting;
using System.Runtime.Intrinsics.X86;

namespace EncycloBook.Tests.CommentTests
{
    public class CommentTests
    {
        private ApplicationDbContext dbContext ;
        private ICommentServices commentServices;
        private ApplicationUser user;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase"+ Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.commentServices = new CommentServices(this.dbContext);
            this.user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "testUser",
                Email = "test@example.com",
                Comments = new List<Comment>()
            };

        }

        [Test]
        public async Task CommentPostAddsCommentToPostAndUserWhenUserNotNull()
        {

            // Test data setup
            var post = new Animal()
            {

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
                Comments = new List<Comment>(),
                IsWild = true, // Set whether the animal is wild or not};

            };
                await dbContext.AddAsync(post);
                await dbContext.SaveChangesAsync();

                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();
            
         

            var comment = new Comment()
            {
              Id = 1,
                Content = "A",
                PublishedOn = DateTime.Now,
                Publisher = user,
                PublisherId = user.Id,
            };

            // Act
            await commentServices.CommentPost(post, user, comment);

            // Assert
            Assert.That(1, Is.EqualTo(post.Comments.Count));
            Assert.That(comment, Is.EqualTo(post.Comments.FirstOrDefault(x => x.Id == 1)));
            Assert.That(1, Is.EqualTo(user.Comments.Count));
            Assert.That(comment, Is.EqualTo(user.Comments.FirstOrDefault(x => x.Id == 1)));
            Assert.That(1, Is.EqualTo(dbContext.Comments.Count()));
            Assert.That(comment, Is.EqualTo(dbContext.Comments.FirstOrDefault(x => x.Id == 1)));
            // Additional assertions for comments can be added here
        }

        [Test]
        public async Task CommentPostDoesNotAddCommentWhenUserIsNull()
        {

           
            // Test data setup
            var post = new Animal()
            {
                
                Title = "Test Animal",
                DiscoveredBy = "Discoverer Name", // Replace with actual discoverer name
                PublishedOn = DateTime.Now, // Set the publication date and time
                ImgURL = "https://example.com/image.jpg", // Replace with actual image URL
                Description = "This is a test animal description.", // Replace with the description
                PublisherId = Guid.NewGuid(), // Replace with actual publisher's GUID
                Location = "Test Location", // Set the animal's location
                Comments = new List<Comment>(),
                AnimalClass = "Mammalia", // Set the animal's class
                AnimalSubClass = "Mammal", // Set the animal's subclass
                FoodId = 1, // Set the Food ID
                IsWild = true, // Set whether the animal is wild or not};

            };
            await dbContext.AddAsync(post);
            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {
               
                Content = "A",
                PublishedOn = DateTime.Now,
                Publisher = user,
                PublisherId = user.Id,
            };

            // Act
            Assert.ThrowsAsync<ArgumentException>(async () => await commentServices.CommentPost(post, null, comment));


        }
        [Test]
        public async Task CommentPostDoesNotAddCommentWhenPostIsNull()
        {


            // Test data setup
      
           
            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {

                Content = "A",
                PublishedOn = DateTime.Now,
                Publisher = user,
                PublisherId = user.Id,
            };

            // Act
            Assert.ThrowsAsync<ArgumentException>(async () => await commentServices.CommentPost(null, user, comment));


        }
        [Test]
        public async Task CommentPostDoesNotAddCommentWhenCommentIsNull()
        {


            // Test data setup


            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {

                Content = "A",
                Publisher = user,
                PublishedOn = DateTime.Now,
                PublisherId = user.Id,
            };

            // Act
 

            // Assert

            Assert.ThrowsAsync<ArgumentException>(async () => await commentServices.CommentPost(null, null, null));


        }
        [Test]
        public async Task CommentGetsAddedCorrectly()
        {

        
            // Test data setup
            var post = new Animal()
            {
                Title = "Test Animal",
                DiscoveredBy = "Discoverer Name", // Replace with actual discoverer name
                PublishedOn = DateTime.Now, // Set the publication date and time
                ImgURL = "https://example.com/image.jpg", // Replace with actual image URL
                Description = "This is a test animal description.", // Replace with the description
                PublisherId = Guid.NewGuid(), // Replace with actual publisher's GUID
                Location = "Test Location", // Set the animal's location
                AnimalClass = "Mammalia", // Set the animal's class
                Comments = new List<Comment>(),
                AnimalSubClass = "Mammal", // Set the animal's subclass
                FoodId = 1, // Set the Food ID
                IsWild = true, // Set whether the animal is wild or not};

            };
            await dbContext.AddAsync(post);
            await dbContext.SaveChangesAsync();

            var comment = new Comment()
            {
             
                Content = "Test!",
                Publisher = user,
                PublishedOn = DateTime.Now,
                PublisherId = user.Id,
            };

            // Act
            await commentServices.CommentPost(post, user, comment);

            // Assert
            Assert.That("Test!", Is.EqualTo(post.Comments.FirstOrDefault(x => x.Id == 1).Content));

        }
        [Test]
        public async Task CommentPostThrowsExceptionWhenUserIsNull()
        {
            // Arrange
            var post = new Animal();
            Comment comment = null;
            var user1 = new ApplicationUser();

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await commentServices.CommentPost(post, user1, comment));
        }

    }
}
