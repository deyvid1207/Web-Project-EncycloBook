    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EncycloData.Models
    {
        public class Animal : Post
        {
      
            public string Location { get; set; } = null!;
      
            public string AnimalClass { get; set; } = null!;

            public string AnimalSubClass { get; set; } = null!;
 
            public int FoodId { get; set; }
            [ForeignKey("FoodId")]
            public Food Food { get; set; } = null!;

            public bool IsWild { get; set; }

        }
    }
