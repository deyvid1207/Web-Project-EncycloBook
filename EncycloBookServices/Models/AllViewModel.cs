using EncycloData.Models;
using System.Numerics;

namespace EncycloBookProject.Models
{
    public class AllViewModel 
    {
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Fungus> Fungi { get; set; }
        public IEnumerable<Plant> Plants { get; set; }
        public IEnumerable<Bacteria> Bacterias { get; set; }
        public IEnumerable<Virus> Viruses { get; set; }

        public AllViewModel()
        {
            Animals = new List<Animal>();
            Fungi = new List<Fungus>();
            Plants = new List<Plant>();
            Bacterias = new List<Bacteria>();
            Viruses = new List<Virus>();
        }
    }
}
