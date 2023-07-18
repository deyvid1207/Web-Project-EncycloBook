using EncycloData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<Fungus> Fungi { get; set; } = null!;
        public DbSet<Bacteria> Bacteria { get; set; } = null!;
      public DbSet<Virus> Viruses { get; set; } = null!;
      public DbSet<Comment> Comments { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
               .HasOne(p => p.Publisher)
               .WithMany()
               .HasForeignKey(p => p.PublisherId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
