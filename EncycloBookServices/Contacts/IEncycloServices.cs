using EncycloData;
using EncycloData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EncycloBookServices.Contacts
{
    public interface IEncycloServices
    {
        public ApplicationUser GetUser(string name);
        public List<Food> GetFood();
        public List<Symptom> GetSymptoms();
        public Task PostAnimalAsync(Animal model);
        public Task PostPlantAsync(Plant model);
        public Task PostFungusAsync(ParasiticFungus model);
        public Task PostBacteriaAsync(DeadlyBacteria model);
        public Task PostVirusAsync(Virus model);
        public AllViewModel ViewAll();
        public AllViewModel SearchAsync(string search);
        public Post FindPost(int id, string type);
        public Task LikePost(Post post, string username);

    }
}
