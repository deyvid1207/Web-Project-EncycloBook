using EncycloBookProject.Models;
using EncycloBookServices.Contacts;
using EncycloData;
using EncycloData.Migrations;
using EncycloData.Models;
using Microsoft.CodeAnalysis.CSharp;
  
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
 

namespace EncycloBookServices
{

    public class EncycloServices : IEncycloServices
    {
        private readonly ApplicationDbContext dbContext;
 

        public EncycloServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Food> GetFood()
        {
            var list = dbContext.Food.ToList();
            return list;
            
        }
        public List<Symptom> GetSymptoms()
        {
            var list = dbContext.Symptoms.ToList();
            return list;

        }
        public ApplicationUser GetUser(string name)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Email == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task PostAnimalAsync(Animal model) {

           
            if (model == null)
            {
                throw new Exception("Animal is null, please enter it correct!");

            }
            else
            {
                    var animal = new Animal()
                {
                   
                    Title = model.Title,
                    Location = model.Location,
                    AnimalSubClass = model.AnimalSubClass,
                    FoodId = model.FoodId,
                    Food = model.Food,
                    IsWild = model.IsWild,
                    ImgURL = model.ImgURL,
                    DiscoveredBy = model.DiscoveredBy,
                        YearDiscovered= model.YearDiscovered,
                    AnimalClass = model.AnimalClass,
                    Description = model.Description,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(animal);
                await dbContext.Animals.AddAsync(animal);
               


            }
            await dbContext.SaveChangesAsync();

        }
        public async Task PostPlantAsync(Plant model)
        {


            if (model == null)
            {
                throw new Exception("Plant is null, please enter it correct!");

            }
            else
            {
                var plant = new Plant()
                {

                    Title = model.Title,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    PlantClass = model.PlantClass,
                    Description = model.Description,
                    LeaveType = model.LeaveType,
                    StemType = model.StemType,
                    RootType = model.RootType,
                    Color = model.Color,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(plant);
                await dbContext.Plants.AddAsync(plant);



            }
            await dbContext.SaveChangesAsync();

        }
        public async Task PostFungusAsync(ParasiticFungus model)
        {


            if (model == null)
            {
                throw new Exception("Fungus is null, please enter it correct!");

            }
            else
            {
                if (model.IsParasitic)
                {
                    var pFungus = new ParasiticFungus()
                    {
                        Title = model.Title,
                        Location = model.Location,
                        ImgURL = model.ImgURL,
                        FungusClass = model.FungusClass,
                        Description = model.Description,
                        GillsType = model.GillsType,
                        IsParasitic = model.IsParasitic,
                        IsPoisonous = model.IsPoisonous,
                        DiscoveredBy = model.DiscoveredBy,
                        YearDiscovered = model.YearDiscovered,
                        Color = model.Color,
                        Comments = model.Comments,
                        PublishedOn = DateTime.Now,
                        PublisherId = model.PublisherId,
                        Publisher = model.Publisher,
                        Likes = model.Likes,
                        Symptom = model.Symptom,
                        Host = model.Host,
                    
                };

                         model.Publisher.Posts.Add(pFungus);
                    await dbContext.Fungi.AddAsync(pFungus);
                }
                else
                {
                        
 
                var fungus = new Fungus()
                {

                    Title = model.Title,
                    Location = model.Location,
                    ImgURL = model.ImgURL,
                    FungusClass = model.FungusClass,
                    Description = model.Description,
                    GillsType = model.GillsType,
                    IsParasitic = model.IsParasitic,
                    IsPoisonous = model.IsPoisonous,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Color = model.Color,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(fungus);
                await dbContext.Fungi.AddAsync(fungus);

                }

            }
            await dbContext.SaveChangesAsync();

     
        }
        public async Task PostBacteriaAsync(DeadlyBacteria model)
        {


            if (model == null)
            {
                throw new Exception("Bacteria is null, please enter it correct!");

            }
            else
            {
                if (model.IsDeadly)
                {
                    var Dbacteria = new DeadlyBacteria()
                    {

                        Title = model.Title,
                        ImgURL = model.ImgURL,
                        BacteriaFamily = model.BacteriaFamily,
                        Description = model.Description,
                        IsDeadly = model.IsDeadly,
                        DiscoveredBy = model.DiscoveredBy,
                        YearDiscovered = model.YearDiscovered,
                        Comments = model.Comments,
                        PublishedOn = DateTime.Now,
                        PublisherId = model.PublisherId,
                        Publisher = model.Publisher,
                        Likes = model.Likes,
                        Host = model.Host,
                        SymptomId = model.SymptomId,
                        Symptom = model.Symptom,
                    };
                    model.Publisher.Posts.Add(Dbacteria);
                    await dbContext.Bacteria.AddAsync(Dbacteria);
                }
                else
                {

               
                var bacteria = new Bacteria()
                {

                    Title = model.Title,
                    ImgURL = model.ImgURL,
                    BacteriaFamily = model.BacteriaFamily,
                    Description = model.Description,
                    IsDeadly = model.IsDeadly, 
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                    model.Publisher.Posts.Add(bacteria);
                    await dbContext.Bacteria.AddAsync(bacteria);
                }
                
               



            }
            await dbContext.SaveChangesAsync();

        }
        public async Task PostVirusAsync(Virus model)
        {


            if (model == null)
            {
                throw new Exception("Virus is null, please enter it correct!");

            }
            else
            {
                var Virus = new Virus()
                {

                    Title = model.Title,
                    ImgURL = model.ImgURL,
                    VirusFamily = model.VirusFamily,
                    Description = model.Description,
                    VirusHost = model.VirusHost,
                    Symptom = model.Symptom,
                    DiscoveredBy = model.DiscoveredBy,
                    YearDiscovered = model.YearDiscovered,
                    Comments = model.Comments,
                    PublishedOn = DateTime.Now,
                    PublisherId = model.PublisherId,
                    Publisher = model.Publisher,
                    Likes = model.Likes
                };
                model.Publisher.Posts.Add(Virus);
                await dbContext.Viruses.AddAsync(Virus);



            }
            await dbContext.SaveChangesAsync();

        }

        public AllViewModel ViewAll()
        {

            var all = new AllViewModel();
            all.Posts.AddRange(dbContext.Animals.Include(a => a.Publisher).Include(a => a.Comments).Include(a => a.Likes));
            all.Posts.AddRange(dbContext.Plants.Include(p => p.Publisher).Include(a => a.Comments).Include(a => a.Likes));
            all.Posts.AddRange(dbContext.Viruses.Include(v => v.Publisher).Include(a => a.Comments).Include(a => a.Likes));
            all.Posts.AddRange(dbContext.Bacteria.Include(b => b.Publisher).Include(a => a.Comments).Include(a => a.Likes));
            all.Posts.AddRange(dbContext.Fungi.Include(f => f.Publisher).Include(a => a.Comments).Include(a => a.Likes));

            return all;
        }


        public AllViewModel SearchAsync(string search)
        {
            var d = new List<Post>();
            
            if (search == null)
            {
                 d = ViewAll().Posts.ToList();
            }
            else
            {
                d = ViewAll().Posts.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();

            }
           
            AllViewModel v = new AllViewModel();
                v.Posts = d;
             return v;

        }

        public Post FindPost(int id, string type)
        {
            Post post;
            switch (type)
            {
                case "Animal":
                    post = new Animal();
                    post = dbContext.Animals.Include(a => a.Publisher).Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Food).Include(x => x.Likes).FirstOrDefault(a => a.Id == id);
                    break;
                case "Plant":
                    post = new Plant();
                    post = dbContext.Plants.Include(a => a.Publisher).Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).FirstOrDefault(a => a.Id == id);
                    break;
                case "Fungus":
                    post = new Fungus();
                    post = dbContext.Fungi.Include(a => a.Publisher).Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).FirstOrDefault(a => a.Id == id);
                    break;
                case "Virus":
                    post = new Virus();
                    post = dbContext.Viruses.Include(a => a.Publisher).Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).Include(x => x.Symptom).FirstOrDefault(a => a.Id == id);
                    break;
                case "Bacteria":
                    post = new Bacteria();
                    post = dbContext.Bacteria.Include(a => a.Publisher).Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).FirstOrDefault(a => a.Id == id);
                    break;
                case "DeadlyBacteria":
                    post = new DeadlyBacteria();
                    post = dbContext.Bacteria.OfType<DeadlyBacteria>().Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).Include(a => a.Publisher).Include(x => x.Symptom).FirstOrDefault(a => a.Id == id);
                    break;
                case "ParasiticFungus":
                    post = new ParasiticFungus();
                    post = dbContext.Fungi.OfType<ParasiticFungus>().Include(a => a.Comments).ThenInclude(c => c.Publisher).Include(x => x.Likes).Include(a => a.Publisher).Include(x => x.Symptom).FirstOrDefault(a => a.Id == id);
                    break;
                default:
                    throw new ArgumentException("Post must be assigned!");
                   
            }

            return post;
      
        }
        public async Task LikePost(Post post, string username)
        {
     
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                
            }
            else if (post.Likes.FirstOrDefault(x => x.UserId == user.Id) == null)
            {

                Like Like = new Like()
                {
                    PostId = post.Id,
                    Post = post,
                    User = user,
                    LikedOn = DateTime.Now,
                    UserId = user.Id
                };
                 post.Likes.Add(Like);
            }
            else
            {
              var Like =  post.Likes.FirstOrDefault(x => x.UserId == user.Id);
                post.Likes.Remove(Like);
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task CommentPost(Post post, ApplicationUser user, Comment comment)
        {
         
            if (user == null)
            {

            }
            else 
            {

                dbContext.Comments.Add(comment);
                post.Comments.Add(comment);
                user.Comments.Add(comment);
            }
 
         
            await dbContext.SaveChangesAsync();
        }

        public async Task EditAnimal(Animal post )
        {

            Animal curPost = (Animal)FindPost(post.Id, "Animal");
            curPost.Title = post.Title;
            curPost.ImgURL = post.ImgURL;
            curPost.Food = post.Food;
            curPost.AnimalClass = post.AnimalClass;
            curPost.AnimalSubClass = post.AnimalSubClass;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Location = post.Location;
            curPost.IsWild = post.IsWild;
            curPost.Publisher = post.Publisher;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditPlant(Plant post)
        {

            Plant curPost = (Plant)FindPost(post.Id, "Plant");
            curPost.Title = post.Title;
            curPost.ImgURL = post.ImgURL;
            curPost.StemType = post.StemType;
            curPost.Color = post.Color;
            curPost.PlantClass = post.PlantClass;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Location = post.Location;
            curPost.RootType = post.RootType;
            curPost.LeaveType = post.LeaveType;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditFungus(Fungus post)
        {

            Fungus curPost = (Fungus)FindPost(post.Id, "Fungus");
            curPost.Title = post.Title;
            curPost.ImgURL = post.ImgURL;
            curPost.IsPoisonous = post.IsPoisonous;
            curPost.Color = post.Color;
            curPost.FungusClass = post.FungusClass;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Location = post.Location;
            curPost.GillsType = post.GillsType;
            curPost.IsParasitic = false;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditParasiticFungus(ParasiticFungus post)
        {

            ParasiticFungus curPost = (ParasiticFungus)FindPost(post.Id, "ParasiticFungus");
            curPost.Title = post.Title;
            curPost.ImgURL = post.ImgURL;
            curPost.IsPoisonous = post.IsPoisonous;
            curPost.Color = post.Color;
            curPost.FungusClass = post.FungusClass;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Location = post.Location;
            curPost.GillsType = post.GillsType;
            curPost.IsParasitic = true;
            curPost.Symptom = post.Symptom;
            curPost.Host = post.Host;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditBacteria(Bacteria post)
        {

            Bacteria curPost = (Bacteria)FindPost(post.Id, "Bacteria");
            curPost.Title = post.Title;
            curPost.ImgURL = post.ImgURL;
            curPost.BacteriaFamily = post.BacteriaFamily;
            curPost.IsDeadly = false;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditDeadlyBacteria(DeadlyBacteria post)
        {

            DeadlyBacteria curPost = (DeadlyBacteria)FindPost(post.Id, "DeadlyBacteria");
            curPost.Title = post.Title;
            curPost.Host = post.Host;
            curPost.Symptom = post.Symptom;
            curPost.ImgURL = post.ImgURL;
            curPost.BacteriaFamily = post.BacteriaFamily;
            curPost.IsDeadly = true;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }
        public async Task EditVirus(Virus post)
        {

            Virus curPost = (Virus)FindPost(post.Id, "Virus");
            curPost.Title = post.Title;
            curPost.VirusHost = post.VirusHost;
            curPost.Symptom = post.Symptom;
            curPost.ImgURL = post.ImgURL;
            curPost.VirusFamily = post.VirusFamily;
            curPost.Symptom = post.Symptom;
            curPost.DiscoveredBy = post.DiscoveredBy;
            curPost.YearDiscovered = post.YearDiscovered;
            curPost.PublishedOn = DateTime.Now;
            curPost.Description = post.Description;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePost(int id, string type)
        {
            var post = FindPost(id, type);
            var comments = new List<Comment>();    
            if (post != null)
            {
                switch (type)
                {
                    case "Animal":
                        dbContext.Animals.Remove((Animal)post);

                        
                        break;
                    case "Plant":
                        dbContext.Plants.Remove((Plant)post);
                        break;
                    case "Fungus":
                        dbContext.Fungi.Remove((Fungus)post);
                        break;
                    case "Virus":
                        dbContext.Viruses.Remove((Virus)post);
                        break;
                    case "Bacteria":
                        dbContext.Bacteria.Remove((Bacteria)post);
                        break;
                    case "DeadlyBacteria":
                        dbContext.Bacteria.Remove((DeadlyBacteria)post);
                        break;
                    case "ParasiticFungus":
                        dbContext.Fungi.Remove((ParasiticFungus)post);
                        break;
                    default:
                        throw new ArgumentException("Post must be assigned!");

                }
                comments = post.Comments.ToList();

                dbContext.Comments.RemoveRange(comments);
            }
            await dbContext.SaveChangesAsync();
        }
    }
     
}
 

 