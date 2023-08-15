using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data;

namespace EncycloBook.Services.FoodServices
{
    public class FoodServices : IFoodServices
    {
        private readonly ApplicationDbContext dbContext;


        public FoodServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Food> GetFood()
        {
            var list = dbContext.Food.ToList();
            return list;

        }
    }
}
