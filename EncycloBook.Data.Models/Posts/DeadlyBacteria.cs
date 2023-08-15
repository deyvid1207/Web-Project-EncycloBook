using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Data.Models.Posts
{
    public class DeadlyBacteria : Bacteria
    {
        [Required]
        public string Host { get; set; }
        [Required]
        public int SymptomId { get; set; }
        [ForeignKey("SymptomId")]
        public Symptom Symptom { get; set; } = null!;
    }
}
