using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookServices.Models
{
    public class BacteriaWithSymptomsViewModel
    {
        public BacteriaWithSymptomsViewModel()
        {
            DeadlyBacteria = new DeadlyBacteria();
        }

        public DeadlyBacteria DeadlyBacteria { get; set; }
        public List<Symptom> SymptomList { get; set;}
        public int Id { get; set; }
    }
}
