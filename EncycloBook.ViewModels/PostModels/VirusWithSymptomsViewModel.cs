using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.ViewModels.PostModels
{
    public class VirusWithSymptomsViewModel
    {
        public Virus Virus { get; set; }

        public List<Symptom> SymptomList { get; set; }
        public VirusWithSymptomsViewModel()
        {
            SymptomList = new List<Symptom>();
        }
        public int Id { get; set; }
    }
}
