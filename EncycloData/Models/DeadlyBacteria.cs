using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData.Models
{
    public class DeadlyBacteria : Bacteria
    {
        [Required]
        public string Host = null!;
        [Required]
        public Symptom Symptom { get; set; } = null;
    }
}
