using EncycloBookData;
using EncycloBookData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EncycloBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<PostUser>
    {
        DbSet<Animal> Animals { get; set; } = null!;
        DbSet<Plant> Plants { get; set; } = null!;
        DbSet<Fungus> Fungi { get; set; } = null!;  
        DbSet<Bacteria> Bacteria { get; set; } = null!;

        DbSet<Virus> Viruses { get; set; } = null!;
        DbSet<Comment> Comments { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}