using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData.Models
{
    public class ParasiticFungus : Fungus
    {
 
        [Required]
        public string Host { get; set; } = null!;

        [Required]
        public int SymptomId { get; set; }
        [ForeignKey("SymptomId")]
        public Symptom Symptom { get; set; } = null!;
    }
}
