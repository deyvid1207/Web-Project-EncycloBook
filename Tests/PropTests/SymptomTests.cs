using EncycloBook.Data;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Services.FoodServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.SymptomServices;
using EncycloBook.Data.Models.Properties;

namespace EncycloBook.Tests.PropTests
{
    [TestFixture]
    public class SymptomTests
    {
        private ApplicationDbContext dbContext;
        private ISymptomServices symptomServices;

        [SetUp]
        public void SetUp()
        {
            // Initialize an in-memory database context for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);
            this.symptomServices = new SymptomServces(this.dbContext);
           

        }
        [Test]
        public async Task SymptomGetsFoundCorrect()
        {

            var Symptom1 = new Symptom()
            {
                Id = 1,
                Name = "Test",
            };
            var Symptom2 = new Symptom()
            {
                Id = 2,
                Name = "Test1",
            };
            await dbContext.Symptoms.AddRangeAsync(Symptom1, Symptom2);
            await dbContext.SaveChangesAsync();
            var foodList = symptomServices.GetSymptoms();
            Assert.IsNotNull(foodList);
            Assert.That(foodList.Count, Is.EqualTo(dbContext.Symptoms.Count()));
            Assert.That(Symptom1, Is.EqualTo(dbContext.Symptoms.FirstOrDefault(x => x.Id == 1)));
            Assert.That(Symptom2, Is.EqualTo(dbContext.Symptoms.FirstOrDefault(x => x.Id == 2)));
        }
    }
}
