using EncycloBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Infrastructure.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IPostModel product)
        {
            return product.Title.Replace(" ", "-");
        }
    }
}
