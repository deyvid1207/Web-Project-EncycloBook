using EncycloBook.Data.Models.Posts;
using EncycloBook.Data;
using EncycloBook.ViewModels.AllViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EncycloBook.Services.AllPostsServices
{
    public class AllPostServices
    {
        private readonly ApplicationDbContext dbContext;


        public AllPostServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
