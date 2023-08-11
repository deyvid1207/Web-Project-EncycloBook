using EncycloBookServices;
using EncycloBookServices.Contacts;
using EncycloData;
using EncycloData.Migrations;
using EncycloData.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Policy;

namespace Tests
{
    public class Tests
    {
        private ApplicationDbContext dbContext;
        private IEncycloServices encycloServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.encycloServices = new EncycloServices(this.dbContext);
           
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
                YearDiscovered = DateTime.UtcNow,
                FoodId = 1,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = guid, // Set the foreign key value
                Publisher = testUser,
            };
            await encycloServices.PostAnimalAsync(Girrafe);

            // Retrieve the added animal from the context
            var addedAnimal = dbContext.Animals.FirstOrDefault(a => a.Title == "Giraffaae");

            // Assert that the added animal is not null
            Assert.NotNull(addedAnimal);

            // Assert the properties of the added animal
            Assert.AreEqual(Girrafe.Title, addedAnimal.Title);
    
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

            var test = new Plant()
            {

                Title = "Test",
                PlantClass = "Test",
                Description = "Test Test Test.",
                DiscoveredBy = "Test",
                YearDiscovered = DateTime.UtcNow,
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
            await encycloServices.PostPlantAsync(test);

            // Retrieve the added animal from the context
            var addedPlant= dbContext.Plants.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedPlant);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedPlant.Title);
            // ... (other property assertions)
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
                YearDiscovered = DateTime.UtcNow,
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
            await encycloServices.PostFungusAsync(test);

            // Retrieve the added animal from the context
            var addedFungus = dbContext.Fungi.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedFungus);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedFungus.Title);
            // ... (other property assertions)
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
                YearDiscovered = DateTime.UtcNow,
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
            await encycloServices.PostFungusAsync(test);

            // Retrieve the added animal from the context
            var addedFungus = dbContext.Fungi.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedFungus);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedFungus.Title);
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
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                  VirusFamily = "Test",
                       
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await encycloServices.PostVirusAsync(test);

            // Retrieve the added animal from the context
            var addedVirus = dbContext.Viruses.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedVirus);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedVirus.Title);
            // ... (other property assertions)
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
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                

                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await encycloServices.PostBacteriaAsync(test);

            // Retrieve the added animal from the context
            var addedBac = dbContext.Bacteria.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedBac);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedBac.Title);
            // ... (other property assertions)
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
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                
                PublishedOn = DateTime.UtcNow,
                Publisher = testUser,
                PublisherId = guid, // Set the foreign key value
            };
            await encycloServices.PostBacteriaAsync(test);

            // Retrieve the added animal from the context
            var addedBac = dbContext.Bacteria.FirstOrDefault(a => a.Title == "Test");

            // Assert that the added animal is not null
            Assert.NotNull(addedBac);

            // Assert the properties of the added animal
            Assert.AreEqual(test.Title, addedBac.Title);
            // ... (other property assertions)
        }
        [Test]
        public void ViewAllReturnsAllPosts()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
            };
            // Test data setup
            var animal = new Animal() {
                Title = "Giraffaae",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = DateTime.UtcNow,
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
                YearDiscovered = DateTime.UtcNow,
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

                dbContext.AddRange(animal, plant); 

            dbContext.SaveChanges();

            var result = encycloServices.ViewAll();

            Assert.AreEqual(2, result.Posts.Count); 
       
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
            var animal = new Animal() { Title = "Lion",
                AnimalClass = "Mammaaalia Giraffidae",
                AnimalSubClass = "Mamaaamal",
                IsWild = true,
                Description = "The girafaaafe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaaaeus",
                YearDiscovered = DateTime.UtcNow,
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
                YearDiscovered = DateTime.UtcNow,
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
            var result = encycloServices.SearchAsync("lion");

            // Assert
            Assert.AreEqual(1, result.Posts.Count);
            Assert.AreEqual("Lion", result.Posts[0].Title);
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
                YearDiscovered = DateTime.UtcNow,
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
                YearDiscovered = DateTime.UtcNow,
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
            var result = encycloServices.SearchAsync(null);

            // Assert
            Assert.AreEqual(2, result.Posts.Count); // Adjust count based on your test data
            // Additional assertions for specific properties can be added here
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
            dbContext.Users.Add(user);

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
            dbContext.Animals.Add(post);
            await dbContext.SaveChangesAsync();

            // Act
            await encycloServices.LikePost(post, user.UserName);
            var likedPost = dbContext.Animals
                .Include(a => a.Likes)
                .FirstOrDefault(a => a.Id == post.Id);

            // Assert
            Assert.NotNull(likedPost);
            Assert.AreEqual(1, likedPost.Likes.Count);
            Assert.AreEqual(user.Id, likedPost.Likes.First().UserId);
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

            var like = new Like() { PostId = post.Id, UserId = user.Id };
            dbContext.Add(like);
            await dbContext.SaveChangesAsync();

            // Act
            await encycloServices.LikePost(post, user.UserName);

            // Assert
            Assert.AreEqual(0, post.Likes.Count);
            // Additional assertions for likes can be added here
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

            var comment = new Comment() {Id = 1,
            Content = "A",
            PublishedOn = DateTime.Now,
            PublisherId = user.Id};

            // Act
            await encycloServices.CommentPost(post, user, comment);

            // Assert
            Assert.AreEqual(1, post.Comments.Count);
            Assert.AreEqual(1, user.Comments.Count);
            // Additional assertions for comments can be added here
        }

        [Test]
        public async Task CommentPostDoesNotAddCommentWhenUserIsNull()
        {

            ApplicationUser user =null;
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
            await encycloServices.CommentPost(post, user, comment);

            // Assert
            Assert.AreEqual(0, post.Comments.Count);
          
        }
   

    }
    }
