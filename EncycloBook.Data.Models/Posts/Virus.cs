using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data.Models.Properties;
using EncycloBook.Data.Models.Posts;

namespace EncycloBook.Data.Models.Posts
{
    public class Virus : Post
    {
       


        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string VirusFamily { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string VirusHost { get; set; } = null!;
        public int SymptomId { get; set; }
        [ForeignKey("SymptomId")]
        public Symptom Symptom { get; set; } = null!;   
 

    }
}
