using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBook.Services.UserServices;
using EncycloBook.Services.UserServices.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Tests.UserTests
{
    public class UserTests
    {
        private ApplicationDbContext dbContext;
        private IUserServices userServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.userServices = new UserServices(this.dbContext);

        }
        [TearDown]
        public void TearDown()
        {
            // Dispose of the current DbContext to clear the in-memory database
            this.dbContext.Dispose();
        }

        [Test]
        public async Task UserGetsFoundCorrect()
        {
            var guid = Guid.NewGuid();
            var testUser = new ApplicationUser()
            {
                Id = guid,
                UserName = "adminTest",
                Email = "Test@gmail.com",
                
            };

            await this.dbContext.Users.AddAsync(testUser);
         
                await this.dbContext.SaveChangesAsync(); // Save changes to the database
           

            var user = await userServices.GetUser("Test@gmail.com");
            Assert.IsNotNull(user);
            Assert.AreEqual(guid, user.Id);
        }
    }
}
