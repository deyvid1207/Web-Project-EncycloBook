using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.ViewModels.PostModels
{
    public class AnimalWithFoodViewModel
    {
        public AnimalWithFoodViewModel()
        {
            Foods = new List<Food>();
        }
        public Animal Animal { get; set; }
        public List<Food> Foods { get; set; }
    }
}
