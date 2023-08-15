using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.EditServices.Contracts
{
    public interface IEditServices
    {
        public Task EditAnimal(Animal post);
        public Task EditPlant(Plant post);
        public Task EditFungus(Fungus post);
        public Task EditParasiticFungus(ParasiticFungus post);
        public Task EditBacteria(Bacteria post);
        public Task EditDeadlyBacteria(DeadlyBacteria post);
        public Task EditVirus(Virus post);
 
    }
}
