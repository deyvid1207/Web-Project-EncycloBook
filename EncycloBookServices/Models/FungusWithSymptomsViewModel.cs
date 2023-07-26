using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookServices.Models
{
    public class FungusWithSymptomsViewModel
    {
        public ParasiticFungus ParasiticFungus { get; set; }
        public List<Symptom> SymptomList { get; set; }
    }
}
