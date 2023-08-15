using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Models;
using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models.Properties;
using EncycloBookProject.Models;
using EncycloBookServices.Contacts;
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
 

 