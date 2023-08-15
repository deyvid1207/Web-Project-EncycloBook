using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.FoodServices.Contracts
{
    public interface IFoodServices
    {
        public List<Food> GetFood();
    }
}
