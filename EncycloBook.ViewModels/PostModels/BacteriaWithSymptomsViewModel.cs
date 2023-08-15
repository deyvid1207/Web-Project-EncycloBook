using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.ViewModels.PostModels
{
    public class BacteriaWithSymptomsViewModel
    {
        public BacteriaWithSymptomsViewModel()
        {
            DeadlyBacteria = new DeadlyBacteria();
        }

        public DeadlyBacteria DeadlyBacteria { get; set; }
        public List<Symptom> SymptomList { get; set; }
        public int Id { get; set; }
    }
}
