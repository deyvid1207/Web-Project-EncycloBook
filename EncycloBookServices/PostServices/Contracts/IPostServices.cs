using EncycloBook.Data.Models;
using EncycloBook.Data.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.PostServices.Contracts
{
    public interface IPostServices
    {
        public Task PostAnimalAsync(Animal model);
        public Task PostPlantAsync(Plant model);
        public Task PostFungusAsync(ParasiticFungus model);
        public Task PostBacteriaAsync(DeadlyBacteria model);
        public Task PostVirusAsync(Virus model);
        public Post FindPost(int id, string type);
        public Task LikePost(Post post, string username);
        public Task CommentPost(Post post, ApplicationUser username, Comment comment);
        public Task DeletePost(int id, string type);
    }
}
