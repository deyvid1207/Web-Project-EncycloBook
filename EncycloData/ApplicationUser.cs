using EncycloData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            AnimalPosts = new List<Animal>();
            PlantPosts = new List<Plant>();
            VirusPosts = new List<Virus>();
            BacteriaPosts = new List<Bacteria>();
            FungusPosts = new List<Fungus>();
            Comments = new List<Comment>();

        }
        public ICollection<Animal> AnimalPosts { get; set; }     
        public ICollection<Plant> PlantPosts { get; set; }
        public ICollection<Virus> VirusPosts { get; set; }
        public ICollection<Bacteria> BacteriaPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Fungus> FungusPosts { get; set; }

        
        
        }


    }

