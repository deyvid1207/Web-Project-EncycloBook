using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookServices.Models
{
    public class VirusWithSymptomsViewModel
    {
        public Virus Virus { get; set; }

        public List<Symptom> SymptomList { get; set;}
        public VirusWithSymptomsViewModel()
        {
                SymptomList = new List<Symptom>();  
        }
        public int Id { get; set; }
    }
}
