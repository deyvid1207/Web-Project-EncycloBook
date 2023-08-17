﻿using EncycloBook.Data.Models.Posts;
using EncycloBook.Data.Models;
using EncycloBook.Services.CommentServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data;

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
    }
}
