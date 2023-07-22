using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData.Models
{
    public class Fungus : Post
    {

        public string Location { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;

        [Required]
        public string GillsType { get; set; } = null!;
        public bool IsPoisonous { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FungusClass { get; set; } = null!;

    }
}
