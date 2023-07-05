using EncycloBookData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookData
{
    public class EncycloBookContext : DbContext
    {
        DbSet<Animal> Animals { get; set; } = null!;
        DbSet<Bacteria> Bacteria { get; set; } = null!;
        DbSet<Comment> Comments { get; set; } = null!;
        DbSet<Fungus> Fungi { get; set; } = null!;
        DbSet<Plant> Plants { get; set; } = null!;
        DbSet<Virus> Viruses { get; set; } = null!;

        public EncycloBookContext(DbContextOptions options) : base(options)
        {
        }

        protected EncycloBookContext()
        {
        }
    }
}
