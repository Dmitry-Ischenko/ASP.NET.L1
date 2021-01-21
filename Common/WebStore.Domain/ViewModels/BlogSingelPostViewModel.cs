using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Base;

namespace WebStore.Domain.ViewModels
{
    public class BlogSingelPostViewModel : BlogsViewModel
    {
        /// <summary>
        /// Блог
        /// </summary>
        public BlogPost Blog { get; set; }

    }
}
