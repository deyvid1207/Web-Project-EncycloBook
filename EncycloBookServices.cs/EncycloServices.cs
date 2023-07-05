using EncycloBook.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookServices
{
    public class EncycloServices
    {
        private readonly  ApplicationDbContext dbContext;
        public EncycloServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
