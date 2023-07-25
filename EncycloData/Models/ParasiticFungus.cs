using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Symptom Symptom { get; set; }
    }
}
