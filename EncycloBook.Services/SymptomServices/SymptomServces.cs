using EncycloBook.Data;
using EncycloBook.Data.Models.Properties;
using EncycloBook.Services.SymptomServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.SymptomServices
{
    public class SymptomServces : ISymptomServices
    {
        private readonly ApplicationDbContext dbContext;


        public SymptomServces(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Symptom> GetSymptoms()
        {
            var list = dbContext.Symptoms.ToList();
            return list;

        }
    }
}
