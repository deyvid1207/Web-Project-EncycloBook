using EncycloBook.Data.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.ViewModels.CommentViewModel
{
    public class CommentsWithUserId
    {
        public List<Comment> comments { get; set; }

        public Guid Userid { get; set; }
    }
}
