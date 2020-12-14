using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.ViewModels.Base;

namespace WebStore.ViewModels
{
    public class BlogSingelPostViewModel: BlogsViewModel
    {
        /// <summary>
        /// Блог
        /// </summary>
        public BlogPost Blog { get; set; }        

    }
}
