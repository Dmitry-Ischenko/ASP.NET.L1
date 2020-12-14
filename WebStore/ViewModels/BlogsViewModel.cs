using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.ViewModels.Base;

namespace WebStore.ViewModels
{
    public class BlogsViewModel: ViewModel
    {
        /// <summary>
        /// Блоги
        /// </summary>
        public IEnumerable<BlogPost> Blogs { get; set; }
    }
}
