using EncycloData.Models;
using System.Numerics;

namespace EncycloBookProject.Models
{
    public class AllViewModel 
    {
        public List<Post> Posts { get; set; }
 

        public AllViewModel()
        {
            Posts = new List<Post>(); 
        }
    }
}
