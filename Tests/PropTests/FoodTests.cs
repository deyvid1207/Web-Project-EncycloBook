using EncycloBook.Data;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.EditServices;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.PostServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.FoodServices;
using EncycloBook.Data.Models.Properties;

namespace EncycloBook.Tests.PropTests
{
    [TestFixture]
    public class FoodTests
    {
        private ApplicationDbContext dbContext;
        private IFoodServices foodServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.foodServices = new FoodServices(this.dbContext);
   

        }

        [Test]
        public async Task FoodGetsFoundCorrect()
        {
            
            var Food1 = new Food()
            {
                Id = 1,
                Name = "Test",
            };
            var Food2 = new Food()
            {
                Id = 2,
                Name = "Test1",
            };
           await dbContext.Food.AddRangeAsync(Food1, Food2);
            await dbContext.SaveChangesAsync();
            var foodList =  foodServices.GetFood();
            Assert.IsNotNull(foodList);
            Assert.That(foodList.Count, Is.EqualTo(dbContext.Food.Count()));
            Assert.That(Food1, Is.EqualTo(dbContext.Food.FirstOrDefault(x => x.Id == 1)));
            Assert.That(Food2, Is.EqualTo(dbContext.Food.FirstOrDefault(x => x.Id == 2)));

        }
        
    }
}
