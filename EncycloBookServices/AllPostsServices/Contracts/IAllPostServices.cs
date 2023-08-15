using EncycloBook.ViewModels.AllViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Services.AllPostsServices.Contracts
{
    public interface IAllPostServices
    {
        public AllViewModel ViewAll();
        public AllViewModel SearchAsync(string search);
    }
}
