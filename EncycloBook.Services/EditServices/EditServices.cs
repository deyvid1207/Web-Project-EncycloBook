using EncycloBook.Data.Models.Posts;
using EncycloBook.Data;
using EncycloBook.Services.PostServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.PostServices;

namespace EncycloBook.Services.EditServices
{
    public class EditServices : IEditServices
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPostServices postServices;

        public EditServices(ApplicationDbContext dbContext, IPostServices postServices)
        {
            this.dbContext = dbContext;
            this.postServices = postServices;
        }




        public async Task EditAnimal(Animal post)
        {

            Animal curPost = (Animal)await postServices.FindPost(post.Id, "Animal");
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

            Plant curPost = (Plant)await postServices.FindPost(post.Id, "Plant");
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

            Fungus curPost = (Fungus)await postServices.FindPost(post.Id, "Fungus");
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

            ParasiticFungus curPost = (ParasiticFungus)await postServices.FindPost(post.Id, "ParasiticFungus");
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

            Bacteria curPost = (Bacteria)await postServices.FindPost(post.Id, "Bacteria");
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

            DeadlyBacteria curPost = (DeadlyBacteria)await postServices.FindPost(post.Id, "DeadlyBacteria");
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

            Virus curPost = (Virus)await postServices.FindPost(post.Id, "Virus");
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
    }
}
