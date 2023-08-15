using EncycloBook.Data.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.SymptomServices.Contracts
{
    public interface ISymptomServices
    {
        public List<Symptom> GetSymptoms();
    }
}
