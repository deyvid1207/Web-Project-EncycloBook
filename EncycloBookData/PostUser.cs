using EncycloBookData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookData
{
    public class PostUser : IdentityUser
    {

        public ICollection<Bacteria> Bacterias { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<Virus> Viruses { get; set; }
        public ICollection<Plant> Plants { get; set; }
        public ICollection<Fungus> Fungi { get; set; }
        public int Followers = 0;

        public PostUser()
        {
            
            Bacterias = new List<Bacteria>();
            Animals = new List<Animal>();
            Plants = new List<Plant>();
            Viruses = new List<Virus>();
            Fungi = new List<Fungus>();
        }
    }
}
