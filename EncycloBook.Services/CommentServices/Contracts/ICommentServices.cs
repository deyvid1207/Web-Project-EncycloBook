using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.ViewModels.CommentViewModel;

namespace EncycloBook.Services.CommentServices.Contracts
{
    public interface ICommentServices
    {
        public  Task CommentPost(Post post, ApplicationUser user, Comment comment);
        public  Task<CommentsWithUserId> GetAllUserComments(ApplicationUser user);
        public Task RemoveComment(Post post, ApplicationUser user, int commentId);
    }
}
