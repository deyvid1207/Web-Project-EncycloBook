using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData.Models
{
    public class Plant : Post
    {
      
        public string Location { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;
        public int Likes { get; set; } = 0;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string PlantClass { get; set; } = null!;

        [Required]
        public string LeaveType { get; set; } = null!;

   


    }
}
