using EncycloBook.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models.Properties;
using EncycloBook.Data.Models;

namespace EncycloBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<Fungus> Fungi { get; set; } = null!;
        public DbSet<Food> Food { get; set; } = null!;
        public DbSet<Symptom> Symptoms { get; set; } = null!;

        public DbSet<Bacteria> Bacteria { get; set; } = null!;
        public DbSet<Virus> Viruses { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Symptom>().HasData(
       new Symptom { Id = 1, Name = "Fever", IsLifeThreatening = false },
       new Symptom { Id = 2, Name = "Stomachache", IsLifeThreatening = false },
       new Symptom { Id = 3, Name = "Headache", IsLifeThreatening = false },
       new Symptom { Id = 4, Name = "Major Organ Failure", IsLifeThreatening = true },
       new Symptom { Id = 5, Name = "Dehydration", IsLifeThreatening = false },
       new Symptom { Id = 6, Name = "Extreme Dehydration", IsLifeThreatening = true },
       new Symptom { Id = 7, Name = "Fatigue", IsLifeThreatening = false }
   );
            modelBuilder.Entity<Food>().HasData(
    new Food { Id = 1, Name = "Leaves" },
    new Food { Id = 2, Name = "Flowers" },
    new Food { Id = 3, Name = "Grass" },
    new Food { Id = 4, Name = "Mammals" },
    new Food { Id = 5, Name = "Fish" },
    new Food { Id = 6, Name = "Mushrooms" },
    new Food { Id = 7, Name = "Birds" },
    new Food { Id = 8, Name = "Everything" }
);

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
            modelBuilder.Entity<Post>()
    .HasMany(p => p.Likes)
    .WithOne(l => l.Post)
    .HasForeignKey(l => l.PostId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Animal>()
    .HasOne(a => a.Food)
    .WithMany()
    .HasForeignKey(a => a.FoodId)
    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Virus>()
.HasOne(a => a.Symptom)
.WithMany()
.HasForeignKey(a => a.SymptomId)
.OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ParasiticFungus>()
.HasOne(a => a.Symptom)
.WithMany()
.HasForeignKey(a => a.SymptomId)
.OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DeadlyBacteria>()
.HasOne(a => a.Symptom)
.WithMany()
.HasForeignKey(a => a.SymptomId)
.OnDelete(DeleteBehavior.ClientSetNull);
        }
        public void SeedData()
        {
            var adminUserId = Guid.Parse("224a25dd-ceb2-4d1c-bb49-fb99d66972b6");
            var adminUserExists = Users.Any(u => u.Id == adminUserId);
            if (!adminUserExists)
            {
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
                    AnimalSubClass = "Mammal",
                    IsWild = true,
                    Description = "The giraffe is a large African hoofed mammal belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies. Most recently, researchers proposed dividing them into up to eight extant species due to new research into their mitochondrial and nuclear DNA, as well as morphological measurements. Seven other extinct species of Giraffa are known from the fossil record.",
                    DiscoveredBy = "Linnaeus",
                    YearDiscovered = DateTime.UtcNow,
                    FoodId = 1,
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
                    StemType = "Aerogelius",
                    RootType = "Taproot",
                    Color = "White",
                    LeaveType = "Simple",
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
                    ImgURL = "https://microbewiki.kenyon.edu/images/6/64/Scanning-electron-microscope-SEM-photomicrograph-of-a-four-day-old-biofilm-of-R-ruber.png",
                    Likes = new List<Like>(),
                    PublisherId = adminUserId,
                };
                var Parasitic = new ParasiticFungus()
                {
                    Title = "Cordyceps",
                    FungusClass = "Ophiocordyceps sinensis",
                    Description = "Cordyceps is a fungus that has long been used in in traditional Chinese medicine (TCM). Some people use it to try to boost energy and strength, improve immunity, enhance kidney function, and improve sexual dysfunction. It has also been used to treat cough and fatigue. Cordyceps is known as an adaptogen, which means it may help your body adapt to stress.",
                    Color = "Orange",
                    IsParasitic = true,
                    IsPoisonous = true,
                    PublishedOn = DateTime.UtcNow,
                    YearDiscovered = DateTime.UtcNow,
                    GillsType = "None",
                    DiscoveredBy = "Wang Ang",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/5/53/2010-08-06_Cordyceps_militaris_1.jpg",
                    Host = "Ants",
                    SymptomId = 7,
                    Location = "Indonesia",

                    PublisherId = adminUserId,
                    Likes = new List<Like>(),

                };
                adminUser.Posts.Add(Girrafe);
                adminUser.Posts.Add(Edelweiss);
                adminUser.Posts.Add(Bac);
                adminUser.Posts.Add(Parasitic);

                Users.Add(adminUser);
                SaveChanges();
            }
        }
    }
}

