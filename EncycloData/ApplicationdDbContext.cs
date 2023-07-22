using EncycloData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public void SeedData()
        {
            var adminUserId = Guid.Parse("224a25dd-ceb2-4d1c-bb49-fb99d66972b6");
            var adminUserExists = this.Users.Any(u => u.Id == adminUserId);
            if (!adminUserExists) {  
            var adminUser = new ApplicationUser()
            {
                Id = adminUserId,
                UserName = "admin",
                Email = "admin@gmail.com",
            };

            var Girrafe = new Animal()
            {
              
                Title = "Giraffe",
                AnimalClass = "Mammalia Giraffidae",
                Description = "The giraffe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                DiscoveredBy = "Linnaeus",
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Giraffe_Mikumi_National_Park.jpg/220px-Giraffe_Mikumi_National_Park.jpg",
                Likes = new List<Like>(),
                Location = "Africa",
                PublishedOn = DateTime.UtcNow,
                PublisherId = adminUserId, // Set the foreign key value
            };

            var Edelweiss = new Plant()
            {
              
                Title = "Edelweiss",
                PlantClass = "Leontopodium nivale",
                Description = "Edelweiss (Leontopodium alpinum) is famous for its lance-shaped, wooly foliage and white, star-shaped flowers. These little flowers are naturally found growing in the high altitudes of the Alps and are accustomed to rocky soil, cold temperatures, and high winds. Edelweiss is a slow-growing plant and will begin flowering in its second year of growth.",
                DiscoveredBy = "Klaus Weiss",
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://upload.wikimedia.org/wikipedia/commons/3/38/Alpen_Edelwei%C3%9F%2C_Leontopodium_alpinum_2.JPG",
                Likes = new List<Like>(),
                Location = "Switzerland",
                PublishedOn = DateTime.UtcNow,
                PublisherId = adminUserId, // Set the foreign key value
            };
            var Bac = new Bacteria()
            {
                Title = "Rhodococcus ruber",
                BacteriaFamily = "Nocardiaceae Rhodococcus",
                Description = "Rhodococcus ruber is a gram positive bacteria that is non-motile and non-spore forming.",
                DiscoveredBy = "William Zopf",
                PublishedOn = DateTime.UtcNow,
                IsDeadly = false,
                YearDiscovered = DateTime.UtcNow,
                ImgURL = "https://microbewiki.kenyon.edu/index.php/File:Scanning-electron-microscope-SEM-photomicrograph-of-a-four-day-old-biofilm-of-R-ruber.png",
                Likes = new List<Like>(),
                PublisherId = adminUserId,
            };

            adminUser.Posts.Add(Girrafe);
            adminUser.Posts.Add(Edelweiss);
            adminUser.Posts.Add(Bac);

            this.Users.Add(adminUser);
            this.SaveChanges();
            }
        }
    }
    }

