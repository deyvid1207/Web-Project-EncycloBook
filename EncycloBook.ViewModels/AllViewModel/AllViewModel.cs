using EncycloBook.Data.Models.Posts;
using System.Numerics;

namespace EncycloBook.ViewModels.AllViewModel
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
