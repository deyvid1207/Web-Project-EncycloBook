using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using EncycloBook.Services.CommentServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data;
using Microsoft.EntityFrameworkCore;
using EncycloBook.ViewModels.CommentViewModel;

namespace EncycloBook.Services.CommentServices
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext dbContext;


        public CommentServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CommentPost(Post post, ApplicationUser user, Comment comment)
        {

            if (user == null || post == null || comment == null)
            {
                // Handle the case when any parameter is null, such as throwing an exception
                throw new ArgumentException("Invalid input parameters");
            }
            else
            {

              await  dbContext.Comments.AddAsync(comment);
                post.Comments.Add(comment);
            }


            await dbContext.SaveChangesAsync();
        }
        public async Task RemoveComment(Post post, ApplicationUser user, int commentId)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (user == null || post == null)
            {
                // Handle the case when any parameter is null, such as throwing an exception
                throw new ArgumentException("Invalid input parameters");
            }
            else
            {

                dbContext.Comments.Remove(comment);
                post.Comments.Remove(comment);
            }


            await dbContext.SaveChangesAsync();
        }
        public async Task<CommentsWithUserId> GetAllUserComments(ApplicationUser user)
        {

            var comments = await dbContext.Comments
                .Where(x => x.PublisherId == user.Id)
                .Include(x => x.Post).ThenInclude(x => x.Likes)
                .Include(x => x.Post).ThenInclude(x => x.Comments).ToListAsync();
            CommentsWithUserId commentsWithUserId = new CommentsWithUserId()
            {
                comments = comments,
                Userid = user.Id
            };
            return commentsWithUserId;    
        }
    }
}
