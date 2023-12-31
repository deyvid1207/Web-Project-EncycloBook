﻿using EncycloBook.Data.Models.Posts;
using EncycloBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EncycloBook.Services.PostServices
{
    public class PostServices : IPostServices
    {
        private readonly ApplicationDbContext dbContext;

                  
        public PostServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task PostAnimalAsync(Animal model)
        {


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
                    YearDiscovered = model.YearDiscovered,
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
                var Like = post.Likes.FirstOrDefault(x => x.UserId == user.Id);
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

            }


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
