using EncycloData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();

            Posts = new List<Post>();
            Comments = new List<Comment>();

        }
  
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }

        
        
        }


    }

